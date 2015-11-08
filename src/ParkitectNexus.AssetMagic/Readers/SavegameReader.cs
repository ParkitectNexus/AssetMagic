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
using ParkitectNexus.AssetMagic.Elements;
using ParkitectNexus.AssetMagic.Utilities;

namespace ParkitectNexus.AssetMagic.Readers
{
    public class SavegameReader : ISavegameReader
    {
        #region Implementation of ISavegameReader

        public virtual ISavegame Deserialize(string data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            var parser = new DataObjectParser(typeof (SavegameHeader), typeof (Park), typeof (Guest));
            var savegame = new Savegame(data.GetFilledLines().Select(parser.Parse).ToArray());

            if(savegame.Header == null)
                throw new InvalidSavegameException("SavegameHeader is missing");
            if(savegame.Park == null)
                throw new InvalidSavegameException("Park is missing");

            return savegame;
        }

        public virtual ISavegame Deserialize(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            using (var streamReader = new StreamReader(stream))
            {
                return Deserialize(streamReader.ReadToEnd());
            }
        }

        #endregion
    }
}