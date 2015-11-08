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
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ParkitectNexus.AssetMagic.JsonConverters;

namespace ParkitectNexus.AssetMagic.Writers
{
    public class SavegameWriter : ISavegameWriter
    {
        #region Implementation of IBlueprintWriter

        public virtual string Serialize(ISavegame savegame)
        {
            if (savegame == null) throw new ArgumentNullException(nameof(savegame));

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new MiniJsonContractResolver(),
                Converters = new[] {new MiniJsonFloatConverter()}
            };

            return string.Concat(savegame.Data.Select(d => JsonConvert.SerializeObject(d, settings) + "\r\n"));
        }

        public virtual void Serialize(ISavegame savegame, Stream stream)
        {
            if (savegame == null) throw new ArgumentNullException(nameof(savegame));
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            using (var streamWriter = new StreamWriter(stream))
                streamWriter.Write(Serialize(savegame));
        }

        #endregion
    }
}