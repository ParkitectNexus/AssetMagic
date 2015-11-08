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
using System.Drawing;
using System.IO;
using System.Linq;
using ParkitectNexus.AssetMagic.Elements;

namespace ParkitectNexus.AssetMagic
{
    public class Savegame : SaveFile, ISavegame
    {
        public Savegame(DataObject[] data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            Data = data;

            Header = GetElement<SavegameHeader>();
            Park = GetElement<Park>();
        }

        #region Implementation of ISavegame

        public virtual ISavegameHeader Header { get; }

        public virtual IPark Park { get; }
        public virtual int GuestCount => GetElements<IGuest>().Count();

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