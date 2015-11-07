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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ParkitectNexus.AssetMagic
{
    public class FileHeader
    {
        protected dynamic Header { get; }

        public FileHeader(JObject header)
        {
            if (header == null) throw new ArgumentNullException(nameof(header));
            Header = header;
        }

        public DateTime Date
        {
            get { return new DateTime((long) Header["date"]); }
            set { Header["date"] = value.Ticks; }
        }
    }

    public class BlueprintHeader : FileHeader
    {
        public BlueprintHeader(JObject header) : base(header)
        {
        }
        
        public string Name
        {
            get { return Header["name"]; }
            set { Header["name"] = value; }
        }

        public int GameVersion
        {
            get { return Header["gameVersion"]; }
            set { Header["gameVersion"] = value; }
        }

        public int SavegameVersion
        {
            get { return Header["savegameVersion"]; }
            set { Header["savegameVersion"] = value; }
        }

        public string GameVersionName
        {
            get { return Header["gameVersionName"]; }
            set { Header["gameVersionName"] = value; }
        }
        
        public string[] Types
        {
            get { return Header["types"].ToObject<string[]>(); }
            set
            {
                Header["types"].RemoveAll();
                Header["types"].Add(value);
            }
        }

        public string Type
        {
            get { return Types.FirstOrDefault(); }
            set { Types = new[] { value }; }
        }
    }

    public class Blueprint : IBlueprint
    {
        private readonly dynamic[] _data;

        public BlueprintHeader Header { get; }

        public Blueprint(byte version, string dataString)
        {
            if (dataString == null) throw new ArgumentNullException(nameof(dataString));

            var data = dataString.Split('\r', '\n')
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Select(JsonConvert.DeserializeObject<dynamic>)
                .ToArray();
            
            Version = version;
            _data = data;
            Header = new BlueprintHeader(_data.FirstOrDefault(d => d["@type"] == "BlueprintHeader"));
        }

        public byte Version { get; }

        public IEnumerable<dynamic> Data => _data;
         
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