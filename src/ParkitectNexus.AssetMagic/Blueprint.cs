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
using ParkitectNexus.AssetMagic.Data;
using ParkitectNexus.AssetMagic.Data.Blueprints;
using ParkitectNexus.AssetMagic.Data.Coasters;

namespace ParkitectNexus.AssetMagic.Converters
{
    public class Blueprint : SaveFile, IBlueprint
    {
        private readonly IEnumerable<IDataElement> _data;

        public Blueprint(IEnumerable<IDataElement> data) : base(data)
        {
            _data = data;

            Header = GetElement<BlueprintHeader>();
            Coaster = GetElement<Coaster>();
        }

        #region Implementation of IBlueprint

        public virtual BlueprintHeader Header { get; }

        public virtual Coaster Coaster { get; }

        #endregion
    }
}