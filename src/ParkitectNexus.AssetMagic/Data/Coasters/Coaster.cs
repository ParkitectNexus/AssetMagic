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

namespace ParkitectNexus.AssetMagic.Data.Coasters
{
    [DataElement("(.*Coaster|WildMouse|MiniatureRailway|Monorail|SuspendedMonorail|LogFlume)")]
    public class Coaster : DataElement
    {
        public int Id { get; set; }

        public float[] Position { get; set; }

        public float[] Rotation { get; set; }

//        public object CarColors { get; set; }

//        public object TrackColors { get; set; }

        public int Track { get; set; }

        public double EntranceFee { get; set; }

        public double Duration { get; set; }

        public TrackedRideStats Stats { get; set; }

        public long TrainCount { get; set; }

        public long TrainLength { get; set; }

        public string CarType { get; set; }

        public long WaitTime { get; set; }

        // TODO add remaining properties
    }
}