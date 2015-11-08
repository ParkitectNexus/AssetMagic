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

using System.Collections.Generic;

namespace ParkitectNexus.AssetMagic.Elements
{
    public class TrackedRideStats : DataObject, ITrackedRideStats
    {
        public TrackedRideStats()
        {
        }

        public TrackedRideStats(IDictionary<string, object> data) : base(data)
        {
        }

        #region Implementation of ITrackedRideStats

        public virtual float MinVertG
        {
            get { return Get<float>("minVertG"); }
            set { Set("minVertG", value); }
        }

        public virtual float MaxVertG
        {
            get { return Get<float>("maxVertG"); }
            set { Set("maxVertG", value); }
        }

        public virtual float MinLatG
        {
            get { return Get<float>("minLatG"); }
            set { Set("minLatG", value); }
        }

        public virtual float MaxLatG
        {
            get { return Get<float>("maxLatG"); }
            set { Set("maxLatG", value); }
        }

        public virtual float AverageLatG
        {
            get { return Get<float>("averageLatG"); }
            set { Set("averageLatG", value); }
        }

        public virtual float MinLongG
        {
            get { return Get<float>("minLongG"); }
            set { Set("minLongG", value); }
        }

        public virtual float MaxLongG
        {
            get { return Get<float>("maxLongG"); }
            set { Set("maxLongG", value); }
        }

        public virtual float MaxVelocity
        {
            get { return Get<float>("maxVelocity"); }
            set { Set("maxVelocity", value); }
        }

        public virtual float MaxVelocityT
        {
            get { return Get<float>("maxVelocityT"); }
            set { Set("maxVelocityT", value); }
        }

        public virtual int DirectionChanges
        {
            get { return Get<int>("directionChanges"); }
            set { Set("directionChanges", value); }
        }

        public virtual int Drops
        {
            get { return Get<int>("drops"); }
            set { Set("drops", value); }
        }

        public virtual float TotalDropHeight
        {
            get { return Get<float>("totalDropHeight"); }
            set { Set("totalDropHeight", value); }
        }

        public virtual float BiggestDrop
        {
            get { return Get<float>("biggestDrop"); }
            set { Set("biggestDrop", value); }
        }

        public virtual float BiggestDropStartT
        {
            get { return Get<float>("biggestDropStartT"); }
            set { Set("biggestDropStartT", value); }
        }

        public virtual int Inversions
        {
            get { return Get<int>("inversions"); }
            set { Set("inversions", value); }
        }

        public virtual float RideLengthTime
        {
            get { return Get<float>("rideLengthTime"); }
            set { Set("rideLengthTime", value); }
        }

        public virtual float RideLengthDistance
        {
            get { return Get<float>("rideLengthDistance"); }
            set { Set("rideLengthDistance", value); }
        }

        public virtual float RatingExcitement
        {
            get { return Get<float>("ratingExcitement"); }
            set { Set("ratingExcitement", value); }
        }

        public virtual float RatingIntensity
        {
            get { return Get<float>("ratingIntensity"); }
            set { Set("ratingIntensity", value); }
        }

        public virtual float RatingNausea
        {
            get { return Get<float>("ratingNausea"); }
            set { Set("ratingNausea", value); }
        }

        public virtual float AirTime
        {
            get { return Get<float>("airTime"); }
            set { Set("airTime", value); }
        }

        public virtual float AverageVelocity
        {
            get { return Get<float>("averageVelocity"); }
            set { Set("averageVelocity", value); }
        }

        public virtual int HeadChoppers
        {
            get { return Get<int>("headChoppers"); }
            set { Set("headChoppers", value); }
        }

        #endregion
    }
}