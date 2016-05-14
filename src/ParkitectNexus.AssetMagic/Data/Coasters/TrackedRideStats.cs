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
    public class TrackedRideStats : DataWrapper
    {
        [WrapProperty]
        public virtual double MinVertG { get; set; }

        [WrapProperty]
        public virtual double MaxVertG { get; set; }

        [WrapProperty]
        public virtual double MinLatG { get; set; }

        [WrapProperty]
        public virtual double MaxLatG { get; set; }

        [WrapProperty]
        public virtual double MinLongG { get; set; }

        [WrapProperty]
        public virtual double MaxLongG { get; set; }

        [WrapProperty]
        public virtual double MaxVelocity { get; set; }

        [WrapProperty]
        public virtual double MaxVelocityT { get; set; }

        [WrapProperty]
        public virtual long DirectionChanges { get; set; }

        [WrapProperty]
        public virtual long Drops { get; set; }

        [WrapProperty]
        public virtual double TotalDropHeight { get; set; }

        [WrapProperty]
        public virtual double BiggestDrop { get; set; }

        [WrapProperty]
        public virtual double BiggestDropStartT { get; set; }

        [WrapProperty]
        public virtual long Inversions { get; set; }

        [WrapProperty]
        public virtual double RideLengthTime { get; set; }

        [WrapProperty]
        public virtual double RideLengthDistance { get; set; }

        [WrapProperty]
        public virtual double RatingExcitement { get; set; }

        [WrapProperty]
        public virtual double RatingIntensity { get; set; }

        [WrapProperty]
        public virtual double RatingNausea { get; set; }

        [WrapProperty]
        public virtual double AirTime { get; set; }

        [WrapProperty]
        public virtual double AverageVelocity { get; set; }

        [WrapProperty]
        public virtual long HeadChoppers { get; set; }
    }
}