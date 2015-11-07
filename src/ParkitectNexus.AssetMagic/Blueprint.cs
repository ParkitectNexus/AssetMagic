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
using System.Linq;
using Newtonsoft.Json;

namespace ParkitectNexus.AssetMagic
{
    public class Blueprint : IBlueprint
    {
        private readonly dynamic[] _data;

        private readonly dynamic _header;
        private byte _version;

        public Blueprint(byte version, string dataString)
        {
            if (dataString == null) throw new ArgumentNullException(nameof(dataString));

            var data = Enumerable.ToArray(dataString.Split('\r', '\n')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(JsonConvert.DeserializeObject<dynamic>));

            _version = version;
            _data = data;
            _header = _data.FirstOrDefault(d => d["@type"] == "BlueprintHeader");
        }

        public string Name
        {
            get { return _header["name"]; }
            set { _header["name"] = value; }
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
            return string.Join("\r\n", _data.Select(d => JsonConvert.SerializeObject(d, new JsonSerializerSettings
            {
                ContractResolver = new MiniJsonContractResolver(),
                Converters = new[] {new MiniJsonFloatConverter()}
            }))) + "\r\n";
        }

        #endregion
    }
}