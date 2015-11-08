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

namespace ParkitectNexus.AssetMagic.Elements
{
    public class Park : DataObject, IPark
    {
        #region Implementation of IPark

        public int Id
        {
            get { return Get<int>("@id"); }
            set { Set("@id", value); }
        }

        public IParkInfo ParkInfo
        {
            get { return Get<ParkInfo>("parkInfo"); }
            set { Set("parkInfo", value); }
        }

        public IParkSettings Settings
        {
            get { return Get<ParkSettings>("settings"); }
            set { Set("settings", value); }
        }

        public string ParkName
        {
            get { return Get<string>("parkName"); }
            set { Set("parkName", value); }
        }

        public string Guid
        {
            get { return Get<string>("guid"); }
            set { Set("guid", value); }
        }

        public int SpawnedAtTime
        {
            get { return Get<int>("spawnedAtTime"); }
            set { Set("spawnedAtTime", value); }
        }

        public int XSize
        {
            get { return Get<int>("xSize"); }
            set { Set("xSize", value); }
        }

        public int ZSize
        {
            get { return Get<int>("zSize"); }
            set { Set("zSize", value); }
        }

        public int YSize
        {
            get { return Get<int>("ySize"); }
            set { Set("ySize", value); }
        }

        public object JobAgency
        {
            get { return Get<object>("jobAgency"); }
            set { Set("jobAgency", value); }
        }

        public object Zones
        {
            get { return Get<object>("zones"); }
            set { Set("zones", value); }
        }

        public bool SendGuestsHome
        {
            get { return Get<bool>("sendGuestsHome"); }
            set { Set("sendGuestsHome", value); }
        }

        public string Patches
        {
            get { return Get<string>("patches"); }
            set { Set("patches", value); }
        }

        public object EmployeeColors
        {
            get { return Get<object>("employeeColors"); }
            set { Set("employeeColors", value); }
        }

        #endregion
    }
}