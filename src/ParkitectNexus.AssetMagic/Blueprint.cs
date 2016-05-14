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

using System.Collections.Generic;
using System.Linq;
using ParkitectNexus.AssetMagic.Data;
using ParkitectNexus.AssetMagic.Data.Blueprints;
using ParkitectNexus.AssetMagic.Data.Coasters;

namespace ParkitectNexus.AssetMagic
{
    public class Blueprint : SaveFile, IBlueprint
    {
        public Blueprint(IEnumerable<IDataWrapper> data) : base(data)
        {
            Header = GetDataWithType<BlueprintHeader>();
            Coasters = GetDataWithTypes(Header.TrackedRideTypes ?? Header.Types).Select(d => d.Cast<Coaster>());
        }
        
        #region Implementation of IBlueprint

        public BlueprintHeader Header { get; }

        public IEnumerable<Coaster> Coasters { get; }

        #endregion
    }
}