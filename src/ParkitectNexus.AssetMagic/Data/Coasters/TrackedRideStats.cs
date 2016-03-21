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

namespace ParkitectNexus.AssetMagic.Data.Coasters
{
    public class TrackedRideStats : DataElement
    {
        public double MinVertG { get; set; }

        public double MaxVertG { get; set; }

        public double MinLatG { get; set; }

        public double MaxLatG { get; set; }

        public double MinLongG { get; set; }

        public double MaxLongG { get; set; }

        public double MaxVelocity { get; set; }

        public double MaxVelocityT { get; set; }

        public long DirectionChanges { get; set; }

        public long Drops { get; set; }

        public double TotalDropHeight { get; set; }

        public double BiggestDrop { get; set; }

        public double BiggestDropStartT { get; set; }

        public long Inversions { get; set; }

        public double RideLengthTime { get; set; }

        public double RideLengthDistance { get; set; }

        public double RatingExcitement { get; set; }

        public double RatingIntensity { get; set; }

        public double RatingNausea { get; set; }

        public double AirTime { get; set; }

        public double AverageVelocity { get; set; }

        public long HeadChoppers { get; set; }
    }
}