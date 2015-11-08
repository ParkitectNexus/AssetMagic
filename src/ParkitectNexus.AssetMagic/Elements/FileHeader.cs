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

namespace ParkitectNexus.AssetMagic.Elements
{
    public class FileHeader : DataObject, IFileHeader
    {
        #region Implementation of IFileHeader

        public virtual DateTime Date
        {
            get { return new DateTime((long) this["date"]); }
            set { this["date"] = value.Ticks; }
        }

        public virtual int SavegameVersion
        {
            get { return Get<int>("savegameVersion"); }
            set { Set("savegameVersion", value); }
        }

        public virtual int GameVersion
        {
            get { return Get<int>("gameVersion"); }
            set { Set("gameVersion", value); }
        }

        public virtual string GameVersionName
        {
            get { return Get<string>("gameVersionName"); }
            set { Set("gameVersionName", value); }
        }

        #endregion
    }
}