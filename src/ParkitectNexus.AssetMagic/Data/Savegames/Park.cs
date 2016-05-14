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

using ParkitectNexus.AssetMagic.Data.Attributes;

namespace ParkitectNexus.AssetMagic.Data.Savegames
{
    public class Park : DataWrapper
    {
        [WrapProperty("@id")]
        public virtual string Id { get; set; }

        [WrapProperty]
        public virtual ParkInfo ParkInfo { get; set; }

        [WrapProperty]
        public virtual ParkSettings Settings { get; set; }

        [WrapProperty]
        public virtual string ParkName { get; set; }

        [WrapProperty]
        public virtual string Guid { get; set; }

        [WrapProperty]
        public virtual long SpawnedAtTime { get; set; }

        [WrapProperty]
        public virtual long XSize { get; set; }

        [WrapProperty]
        public virtual long ZSize { get; set; }

        [WrapProperty]
        public virtual long YSize { get; set; }

        //        public virtual object JobAgency { get; set; }
        //        public virtual object Zones { get; set; }
        [WrapProperty]
        public virtual bool SendGuestsHome { get; set; }

        [WrapProperty]
        public virtual string Patches { get; set; }

//        public virtual object EmployeeColors { get; set; }
    }
}