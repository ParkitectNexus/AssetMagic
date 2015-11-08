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
using System.Linq;
using ParkitectNexus.AssetMagic.Elements;

namespace ParkitectNexus.AssetMagic
{
    public abstract class SaveFile : ISaveFile
    {
        protected SaveFile()
        {
        }

        protected SaveFile(IEnumerable<DataObject> data)
        {
            Data = data;
        }
        
        #region Implementation of ISaveFile

        public IEnumerable<DataObject> Data { get; protected set; }

        public T GetElement<T>() where T : IDataObject
        {
            return GetElements<T>().FirstOrDefault();
        }

        public IEnumerable<T> GetElements<T>() where T : IDataObject
        {
            return Data.OfType<T>();
        }

        #endregion
    }
}