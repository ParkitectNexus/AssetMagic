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
using ParkitectNexus.AssetMagic.Data;

namespace ParkitectNexus.AssetMagic
{
    public abstract class SaveFile : ISaveFile
    {
        protected SaveFile(IEnumerable<IDataWrapper> data)
        {
            Data = data;
        }

        #region Implementation of ISaveFile

        public virtual IEnumerable<IDataWrapper> Data { get; protected set; }

        public IDataWrapper GetDataWithType(string type)
        {
            if (type == null) throw new ArgumentNullException(nameof(type));
            return Data.FirstOrDefault(d => d.Type == type);
        }

        public T GetDataWithType<T>(string type) where T : class, IDataWrapper
        {
            return GetDataWithType(type).Cast<T>();
        }

        public T GetDataWithType<T>() where T : class, IDataWrapper
        {
            return GetDataWithType(typeof(T).Name).Cast<T>();
        }

        public IEnumerable<IDataWrapper> GetDataWithTypes(params string[] types)
        {
            if (types == null) throw new ArgumentNullException(nameof(types));
            return Data.Where(d => types.Contains(d.Type));
        }

        #endregion
    }
}