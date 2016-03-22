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

using System.Linq;
using ParkitectNexus.AssetMagic.Data.Generic;

namespace ParkitectNexus.AssetMagic.Data.Blueprints
{
    public class BlueprintHeader : FileHeader
    {
        public string Name { get; set; }

        public double ApproximateCost { get; set; }

        public string ManufacturerName { get; set; }

        public string[] Types { get; set; }
        public string[] TrackedRideTypes { get; set; }
        public string[] FlatRideTypes { get; set; }
        public string[] DecoTypes { get; set; }
        public ActiveModEntry[] ActiveMods { get; set; }
    }
}