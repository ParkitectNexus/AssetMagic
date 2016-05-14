// ParkitectNexus.AssetTools
// Copyright 2016 Tim Potze
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParkitectNexus.AssetMagic.Data.Attributes;
using ParkitectNexus.AssetMagic.JsonConverters;

namespace ParkitectNexus.AssetMagic.Data
{
    public class DataWrapper : IDataWrapper
    {
        private static readonly Dictionary<Type, Type> Casts = new Dictionary<Type, Type>();

        private static readonly ModuleBuilder ModuleBuilder;

        private readonly Type[] _knownTypes =
        {
            typeof (long),
            typeof (long[]),
            typeof (string),
            typeof (string[]),
            typeof (double),
            typeof (double[]),
            typeof (Dictionary<string, object>)
        };

        static DataWrapper()
        {
            var asmName = new AssemblyName("ProxyAssembly");
            var asmBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(asmName, AssemblyBuilderAccess.RunAndSave);

            ModuleBuilder = asmBuilder.DefineDynamicModule(asmName.Name, asmName.Name + ".dll");
        }

        public DataWrapper()
        {
            Data = new Dictionary<string, object> {["@type"] = GetType().Name};
        }

        internal IDictionary<string, object> Data { get; private set; }
        
        [WrapProperty("@type")]
        public virtual string Type { get; set; }
        
        public object Get(Type type, string key)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (key == null) throw new ArgumentNullException(nameof(key));

            object value;

            // Check for existance
            if (!Data.TryGetValue(key, out value))
                return type.IsValueType ? Activator.CreateInstance(type) : null;

            // Is correct type already
            if (type.IsInstanceOfType(value))
                return value;

            // If wraper is wanted, wrap
            if (typeof (DataWrapper).IsAssignableFrom(type))
            {
                var wrapper = Activator.CreateInstance(type) as DataWrapper;
                var data = value as Dictionary<string, object>;
                if (data != null)
                    wrapper.Data = data;

                return wrapper.Cast(type);
            }

            if (type.IsArray && value is JArray)
                return ((JArray) value).ToObject(type);

            // Needs cast
            throw new Exception("Invalid type to get");
        }

        public void Set(string key, object value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            
            // Check for supported types.
            if (value == null || _knownTypes.Contains(value.GetType()))
            {
                Data[key] = value;
                return;
            }

            // Check for wrappers.
            var wrapper = value as DataWrapper;
            if (wrapper != null)
            {
                Data[key] = wrapper.Data;
                return;
            }

            if (value is int)
                Set(key, (long) (int) value);
            if (value is float)
                Set(key, (double) (float) value);
            else
                throw new Exception("Unsupported value type");
        }

        public T Cast<T>() where T : class, IDataWrapper
        {
            return Cast(typeof (T)) as T;
        }

        public IDataWrapper Cast(Type type)
        {
            if (Casts.ContainsKey(type))
            {
                var t = Casts[type];
                var wrapper = Activator.CreateInstance(t) as DataWrapper;
                wrapper.Data = Data;
                return wrapper;
            }
            else
            {
                var typeBuilder = ModuleBuilder.DefineType(type.Name + "ProxyClass",
                    TypeAttributes.Public | TypeAttributes.Sealed | TypeAttributes.Class, type);

                var didWrapAnything = false;

                foreach (
                    var property in
                        type.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    )
                {
                    var get = property.GetMethod;
                    var set = property.SetMethod;

                    if (!(get?.IsVirtual ?? set.IsVirtual) || property.GetIndexParameters().Length != 0)
                        continue;

                    var attr = property.GetCustomAttribute<WrapPropertyAttribute>();

                    if (attr == null) continue;

                    var newProp = typeBuilder.DefineProperty(property.Name, PropertyAttributes.None,
                        property.PropertyType, System.Type.EmptyTypes);

                    if (get != null)
                    {
                        var methodBuilder = typeBuilder.DefineMethod(get.Name,
                            (get.IsPublic ? MethodAttributes.Public : MethodAttributes.Family) |
                            MethodAttributes.ReuseSlot |
                            MethodAttributes.Virtual | MethodAttributes.HideBySig, get.ReturnType,
                            System.Type.EmptyTypes);

                        var il = methodBuilder.GetILGenerator();

                        // Invoke the native invocation method.
                        var invokeMethodInfo = GetType()
                            .GetMethod("Get", BindingFlags.Instance | BindingFlags.Public);
                            //Get(Type type, string key)

                        il.Emit(OpCodes.Ldarg_0);
                        il.Emit(OpCodes.Ldtoken, property.PropertyType);
                        il.Emit(OpCodes.Call, typeof (Type).GetMethod("GetTypeFromHandle"));

                        il.Emit(OpCodes.Ldstr, property.GetWrappedPropertyName());

                        if (invokeMethodInfo.IsFinal || !invokeMethodInfo.IsVirtual)
                            il.Emit(OpCodes.Call, invokeMethodInfo);
                        else
                            il.Emit(OpCodes.Callvirt, invokeMethodInfo);

                        il.Emit(property.PropertyType.IsValueType
                            ? OpCodes.Unbox_Any
                            : OpCodes.Castclass,
                            property.PropertyType);
                        il.Emit(OpCodes.Ret);

                        newProp.SetGetMethod(methodBuilder);
                    }


                    if (set != null)
                    {
                        var methodBuilder = typeBuilder.DefineMethod(set.Name,
                            (set.IsPublic ? MethodAttributes.Public : MethodAttributes.Family) |
                            MethodAttributes.ReuseSlot |
                            MethodAttributes.Virtual | MethodAttributes.HideBySig, typeof (void),
                            new[] {property.PropertyType});

                        var il = methodBuilder.GetILGenerator();

                        // Invoke the native invocation method.
                        var invokeMethodInfo = GetType()
                            .GetMethod("Set", BindingFlags.Instance | BindingFlags.Public);
                        //Set(string key, object value)
                        
                        il.Emit(OpCodes.Ldarg_0);
                        il.Emit(OpCodes.Ldstr,
                            attr?.Name ?? char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1));

                        il.Emit(OpCodes.Ldarg_1);
                        if (property.PropertyType.IsValueType)
                            il.Emit(OpCodes.Box, property.PropertyType);
                        else
                            il.Emit(OpCodes.Castclass, typeof (object));

                        if (invokeMethodInfo.IsFinal || !invokeMethodInfo.IsVirtual)
                            il.Emit(OpCodes.Call, invokeMethodInfo);
                        else
                            il.Emit(OpCodes.Callvirt, invokeMethodInfo);

                        il.Emit(OpCodes.Ret);

                        newProp.SetSetMethod(methodBuilder);
                    }

                    didWrapAnything = true;
                }

                var t = didWrapAnything ? typeBuilder.CreateType() : type;

                Casts[type] = t;


                var wrapper = Activator.CreateInstance(t) as DataWrapper;
                wrapper.Data = Data;
                return wrapper;
            }
        }

        public static DataWrapper Parse(string input)
        {
            var data = JsonConvert.DeserializeObject<IDictionary<string, object>>(input, new DictionaryConverter());
            return new DataWrapper {Data = data}.Cast<DataWrapper>();
        }
    }
}