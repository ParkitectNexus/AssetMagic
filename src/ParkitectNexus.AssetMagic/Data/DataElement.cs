// ParkitectNexus.AssetMagic
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
using System.Drawing.Design;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Proxies;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParkitectNexus.AssetMagic.Data.Attributes;
using ParkitectNexus.AssetMagic.JsonConverters;
using ParkitectNexus.AssetMagic.Utilities;

namespace ParkitectNexus.AssetMagic.Data
{
    public class DataElement : MarshalByRefObject, IDataElement
    {
        private static readonly Type[] DefaultTypes =
        {
            typeof (string), typeof (double),  typeof (long)
        };

        public DataElement()
        {
            Data = new Dictionary<string, object>();
            Type = GetType().Name;
        }

        public DataElement(IDictionary<string, object> data) : this()
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            foreach (var kv in data)
                Data[kv.Key] = kv.Value;

            FillWithData(Data);
        }

        [IgnoreData]
        internal IDictionary<string, object> Data { get; private set; }

        [IgnoreData]
        public object this[string key]
        {
            get
            {
                if (key == null) throw new ArgumentNullException(nameof(key));
                object value;
                return Data.TryGetValue(key, out value) ? value : null;
            }
            set
            {
                if (key == null) throw new ArgumentNullException(nameof(key));

                var property = GetPropertyForKey(key);

                if (property != null)
                {
                    var propertyType = property.PropertyType;

                    if (!propertyType.IsClass && value == null)
                        throw new ArgumentException("Invalid value type", nameof(value));

                    if (!propertyType.IsInstanceOfType(value))
                        throw new ArgumentException("Invalid value type", nameof(value));

                    property.SetValue(this, value);

                    var valueElement = value as DataElement;
                    Data[key] = valueElement == null ? value : valueElement.Data;
                }
                else
                {
                    Data[key] = value;
                }
            }
        }

        [Data("@type")]
        public string Type { get; set; }

        #region Mapping

        public string[] GetUnmappedProperties()
        {
            return Data.Keys.Where(key => GetPropertyForKey(key) == null).ToArray();
        }

        private PropertyInfo GetPropertyForKey(string key)
        {
            return key == null
                ? null
                : (GetType()
                    .GetProperties()
                    .FirstOrDefault(
                        p => p.GetDataElementName() == key && p.GetCustomAttribute<IgnoreDataAttribute>() == null) ??
                   GetType()
                       .GetProperties()
                       .FirstOrDefault(
                           p =>
                               p.GetCustomAttribute<DataAttribute>()?.Name == key &&
                               p.GetCustomAttribute<IgnoreDataAttribute>() == null));
        }

        private object MapValueToType(object value, Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));

            if (type.IsInstanceOfType(value))
                return value;
            if (type == typeof(DateTime))
            {
                var lValue = (long)value;
                return new DateTime(lValue);
            }
            if (type.IsArray)
            {
                if (value is JArray)
                {
                    var toObject = typeof (JArray).GetMethod("ToObject", new Type[0]);
                    var genericToObject = toObject.MakeGenericMethod(type);
                    return genericToObject.Invoke(value, null);
                }
                else
                {
                    return null;
                }
            }
            if (typeof(DataElement).IsAssignableFrom(type))
            {
                var dictionary = value as IDictionary<string, object>;

                if (dictionary != null)
                {
                    var result = CreateProxyForType(type);
                    result.FillWithData(dictionary);
                    return result;
                }
            }

            throw new Exception("Unsupported type");
        }

        private object UnmapValueFromType(object value, Type type)
        {
            if (type == typeof (DateTime))
            {
                var dateTime = (DateTime) value;
                return dateTime.Ticks;
            }
            if (type.IsArray)
            {
                var array = value as Array;
                var elementType = type.GetElementType();

                return new JArray(array.OfType<object>().Select(v => UnmapValueFromType(v, elementType)).ToArray());
            }
            if (typeof (DataElement).IsAssignableFrom(type))
            {
                var dataElement = value as DataElement;
                return dataElement.Data;
            }
            if (DefaultTypes.Contains(type))
                return value;

            throw new Exception("Unsupported type");
        }

        #endregion

        #region Parsing

        public static DataElement Parse(string input)
        {
            var data = JsonConvert.DeserializeObject<IDictionary<string, object>>(input, new DictionaryConverter());

            var types = typeof (DataElement).Assembly.GetTypesInNameSpaces(true, "ParkitectNexus.AssetMagic.Data");

            var typeName = data["@type"] as string;

            Type type = null;
            if (typeName != null)
            {
                type = types.FirstOrDefault(t => t.Name == typeName) ?? types.FirstOrDefault(t =>
                {
                    var attribute = t.GetCustomAttribute(typeof (DataElementAttribute)) as DataElementAttribute;

                    if (attribute?.Pattern != null)
                    {
                        var regex = new Regex(attribute.Pattern);
                        return regex.IsMatch(typeName);
                    }

                    return false;
                });
            }

            if (type == null)
                type = typeof (DataElement);

            var result = CreateProxyForType(type);
            result.FillWithData(data);
            return result;
        }

        #endregion

        #region Proxy Factory

        public static T Create<T>(string type) where T : DataElement
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            var instance = CreateProxyForType(typeof (T)) as T;
            instance.Type = type;
            return instance;
        }

        public static DataElement Create(string type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return Create<DataElement>(type);
        }

        public static T Create<T>() where T : DataElement
        {
            return Create<T>(typeof (T).Name);
        }

        private static DataElement CreateProxyForType(Type type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            if (!typeof (DataElement).IsAssignableFrom(type)) throw new ArgumentException("Invalid type", nameof(type));

            var result = Activator.CreateInstance(type) as DataElement;
            return (DataElement)
                ((RealProxy)
                    Activator.CreateInstance(typeof (DataElementProxy<>).MakeGenericType(result.GetType()), result))
                    .GetTransparentProxy();
        }

        #endregion

        #region Internal data accessors

        internal void FillWithData(IDictionary<string, object> data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            Data = data;

            foreach (var pair in data)
            {
                var propertyInfo = GetPropertyForKey(pair.Key);
                GetPropertyForKey(pair.Key)?.SetValue(this, MapValueToType(pair.Value, propertyInfo.PropertyType));
            }
        }

        internal void PropertyWasSet(PropertyInfo propertyInfo)
        {
            if (propertyInfo == null) throw new ArgumentNullException(nameof(propertyInfo));
            var dataName = propertyInfo.GetDataElementName();

            if (propertyInfo.PropertyType == typeof (DateTime))
            {
                var value = (DateTime) propertyInfo.GetValue(this);
                Data[dataName] = value.Ticks;
            }
            else if (typeof (DataElement).IsAssignableFrom(propertyInfo.PropertyType))
            {
                // Don't care.
            }
            else if (DefaultTypes.Contains(propertyInfo.PropertyType))
            {
                Data[dataName] = propertyInfo.GetValue(this);
            }
            else
            {
                throw new Exception("Unsupported type");
            }
        }

        #endregion
    }
}