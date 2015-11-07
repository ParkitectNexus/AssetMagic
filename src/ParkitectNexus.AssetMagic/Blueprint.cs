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
using ParkitectNexus.AssetMagic.Elements;
using ParkitectNexus.AssetMagic.Utilities;

namespace ParkitectNexus.AssetMagic
{
    public class Blueprint : IBlueprint
    {
        public Blueprint(byte version, string dataString)
        {
            if (dataString == null) throw new ArgumentNullException(nameof(dataString));

            Version = version;

            var parser = new DataObjectParser(typeof (BlueprintHeader), typeof (Coaster));
            Data = dataString.GetFilledLines().Select(parser.Parse).ToArray();

            Header = GetElement<IBlueprintHeader>();
            Coaster = GetElement<ICoaster>();
        }

        public byte Version { get; }

        public IEnumerable<DataObject> Data { get; }

        public IBlueprintHeader Header { get; }
        public ICoaster Coaster { get; }

        public T GetElement<T>() where T : IDataObject
        {
            return Data.OfType<T>().FirstOrDefault();
        }

        #region Overrides of Object

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return string.Concat(Data.Select(d => d.ToString()));
        }

        #endregion
    }
}