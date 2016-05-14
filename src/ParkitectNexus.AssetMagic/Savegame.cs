// ParkitectNexus.AssetTools
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
using System.Drawing;
using System.IO;
using ParkitectNexus.AssetMagic.Data;
using ParkitectNexus.AssetMagic.Data.Savegames;

namespace ParkitectNexus.AssetMagic
{
    public class Savegame : SaveFile, ISavegame
    {
        public Savegame(IEnumerable<IDataWrapper> data) : base(data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Header = GetDataWithType<SavegameHeader>();
            Park = GetDataWithType<Park>();
        }

        #region Implementation of ISavegame

        public SavegameHeader Header { get; }

        public Park Park { get; }

        public long GuestCount => Header.GuestCount;

        public Image Screenshot
        {
            get
            {
                var bytes = Convert.FromBase64String(Header.Screenshot);
                using (var memoryStream = new MemoryStream(bytes, 0, bytes.Length))
                    return Image.FromStream(memoryStream, true);
            }
        }

        #endregion
    }
}