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
using System.Collections.ObjectModel;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ParkitectNexus.AssetMagic.JsonConverters;

namespace ParkitectNexus.AssetMagic.Elements
{
    public class DataObject : IDataObject
    {
        private readonly IDictionary<string, object> _data;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DataObject" /> class.
        /// </summary>
        public DataObject()
        {
            _data = new Dictionary<string, object>();
        }

        public DataObject(IDictionary<string, object> data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            _data = data;
        }

        public object this[string key]
        {
            get
            {
                object @object;
                return _data.TryGetValue(key, out @object) ? @object : null;
            }
            set { _data[key] = value; }
        }

        public IReadOnlyDictionary<string, object> Data => new ReadOnlyDictionary<string, object>(_data);

        public bool IsEmpty => !_data.Any();

        public virtual string Type
        {
            get { return this["@type"] as string; }
            set { this["@type"] = value; }
        }

        public virtual void Add(string key, object value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (_data.ContainsKey(key))
                throw new ArgumentException("duplicate key", nameof(key));

            _data[key] = value;
        }

        public virtual void Add(KeyValuePair<string, object> keyValuePair)
        {
            Add(keyValuePair.Key, keyValuePair.Value);
        }

        public virtual void AddRange(IEnumerable<KeyValuePair<string, object>> keyValuePairs)
        {
            if (keyValuePairs == null) throw new ArgumentNullException(nameof(keyValuePairs));
            foreach (var keyValuePair in keyValuePairs)
                Add(keyValuePair);
        }

        public T Get<T>(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            var obj = this[key];

            if (typeof (DataObject).IsAssignableFrom(typeof (T)))
            {
                return obj is IDictionary<string, object>
                    ? (T) Activator.CreateInstance(typeof (T), obj as IDictionary<string, object>)
                    : Activator.CreateInstance<T>();
            }

            return (T) Convert.ChangeType(obj, typeof (T));
        }

        public T[] GetArray<T>(string key)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            var obj = this[key];

            var array1 = obj as T[];
            if (array1 != null)
                return array1;

            var array = obj as JArray;
            return array?.Values<T>().ToArray();
        }

        public void Set(string key, object value)
        {
            if (key == null) throw new ArgumentNullException(nameof(key));
            _data[key] = value;
        }
    }
}