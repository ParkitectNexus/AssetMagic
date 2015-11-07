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

using System.Collections.Generic;

namespace ParkitectNexus.AssetMagic.Elements
{
    public interface IDataObject
    {
        object this[string key] { get; set; }
        bool IsEmpty { get; }
        string Type { get; set; }
        void Add(string key, object value);
        void Add(KeyValuePair<string, object> keyValuePair);
        void AddRange(IEnumerable<KeyValuePair<string, object>> keyValuePairs);
        T Get<T>(string key);
        T[] GetArray<T>(string key);
        void Set(string key, object value);
    }
}