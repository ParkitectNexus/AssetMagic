// ParkitectNexus.AssetMagic
// Copyright 2015 Tim Potze
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
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using ParkitectNexus.AssetMagic.Attributes;
using ParkitectNexus.AssetMagic.Elements;
using ParkitectNexus.AssetMagic.JsonConverters;

namespace ParkitectNexus.AssetMagic
{
    public class DataObjectParser
    {
        private readonly IEnumerable<Type> _knownTypes;

        public DataObjectParser()
        {
        }

        public DataObjectParser(IEnumerable<Type> knownTypes)
        {
            _knownTypes = knownTypes;
        }

        public DataObjectParser(params Type[] knownTypes)
        {
            _knownTypes = knownTypes;
        }

        public virtual DataObject Parse(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var data = JsonConvert.DeserializeObject<IDictionary<string, object>>(input, new DictionaryConverter());

            object typeNameObject;
            var type = typeof (DataObject);
            if (data.TryGetValue("@type", out typeNameObject))
            {
                var typeName = typeNameObject as string;
                if (typeName != null)
                {
                    var availableType = _knownTypes?.FirstOrDefault(t => t.Name == typeName) ??
                                        _knownTypes.FirstOrDefault(t =>
                                        {
                                            var attr = t.GetCustomAttribute<DataObjectNameAttribute>();
                                            return attr != null &&
                                                   Regex.IsMatch(typeName, "^" + attr.RegularExpression + "$");
                                        });

                    if (availableType != null && typeof (DataObject).IsAssignableFrom(availableType))
                        type = availableType;
                }
            }

            var instance = Activator.CreateInstance(type) as DataObject;

            instance?.AddRange(data);
            return instance;
        }
    }
}