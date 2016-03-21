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
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Proxies;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using ParkitectNexus.AssetMagic.Data.Attributes;
using ParkitectNexus.AssetMagic.JsonConverters;
using ParkitectNexus.AssetMagic.Utilities;

namespace ParkitectNexus.AssetMagic.Data
{
    public interface IDataElement
    {
        IDictionary<string, object> Data { get; }

        string Type { get; set; }
    }


    public class DataElement : MarshalByRefObject, IDataElement
    {
        private static readonly Type[] DefaultTypes =
        {
            typeof (string), typeof (int), typeof (float), typeof (double), typeof (string[]), typeof (float[]),
            typeof (int[]), typeof (double[]), typeof (long), typeof (long[])
        };

        public DataElement()
        {
            Data = new Dictionary<string, object>();
        }

        [IgnoreData]
        public IDictionary<string, object> Data { get; private set; }

        [Data("@type")]
        public string Type { get; set; }

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


        internal void FillWithData(IDictionary<string, object> data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            Data = data;

            foreach (var pair in data)
            {
                var propertyInfo = GetType().GetProperties().FirstOrDefault(p => p.GetDataElementName() == pair.Key);

                if (propertyInfo == null)
                    continue;

                if (propertyInfo.PropertyType == typeof (DateTime))
                {
                    var value = (long) pair.Value;
                    propertyInfo.SetValue(this, new DateTime(value));
                }
                else if (typeof (DataElement).IsAssignableFrom(propertyInfo.PropertyType))
                {
                    var value = pair.Value as IDictionary<string, object>;

                    if (value != null)
                    {
                        var result = CreateProxyForType(propertyInfo.PropertyType);
                        result.FillWithData(value);
                        propertyInfo.SetValue(this, result);
                    }
                }
                else if (DefaultTypes.Contains(propertyInfo.PropertyType))
                {
                    try
                    {
                        propertyInfo.SetValue(this, pair.Value);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"{propertyInfo}: {e.Message}");
                    }
                }
                else
                {
                    throw new Exception("Unsupported type");
                }
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
    }
}