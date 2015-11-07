using System.Collections.Generic;

namespace ParkitectNexus.AssetMagic
{
    public class TrackedRideStats : DataObject
    {
        public TrackedRideStats()
        {
        }

        public TrackedRideStats(IDictionary<string, object> data) : base(data)
        {
        }

        public float MinVertG
        {
            get { return Get<float>("minVertG"); }
            set { Set("minVertG", value); }
        }

        public float MaxVertG
        {
            get { return Get<float>("maxVertG"); }
            set { Set("maxVertG", value); }
        }

        public float MinLatG
        {
            get { return Get<float>("minLatG"); }
            set { Set("minLatG", value); }
        }

        public float MaxLatG
        {
            get { return Get<float>("maxLatG"); }
            set { Set("maxLatG", value); }
        }

        public float AverageLatG
        {
            get { return Get<float>("averageLatG"); }
            set { Set("averageLatG", value); }
        }

        public float MinLongG
        {
            get { return Get<float>("minLongG"); }
            set { Set("minLongG", value); }
        }

        public float MaxLongG
        {
            get { return Get<float>("maxLongG"); }
            set { Set("maxLongG", value); }
        }

        public float MaxVelocity
        {
            get { return Get<float>("maxVelocity"); }
            set { Set("maxVelocity", value); }
        }

        public float MaxVelocityT
        {
            get { return Get<float>("maxVelocityT"); }
            set { Set("maxVelocityT", value); }
        }

        public int DirectionChanges
        {
            get { return Get<int>("directionChanges"); }
            set { Set("directionChanges", value); }
        }

        public int Drops
        {
            get { return Get<int>("drops"); }
            set { Set("drops", value); }
        }

        public float TotalDropHeight
        {
            get { return Get<float>("totalDropHeight"); }
            set { Set("totalDropHeight", value); }
        }

        public float BiggestDrop
        {
            get { return Get<float>("biggestDrop"); }
            set { Set("biggestDrop", value); }
        }

        public float BiggestDropStartT
        {
            get { return Get<float>("biggestDropStartT"); }
            set { Set("biggestDropStartT", value); }
        }

        public int Inversions
        {
            get { return Get<int>("inversions"); }
            set { Set("inversions", value); }
        }

        public float RideLengthTime
        {
            get { return Get<float>("rideLengthTime"); }
            set { Set("rideLengthTime", value); }
        }

        public float RideLengthDistance
        {
            get { return Get<float>("rideLengthDistance"); }
            set { Set("rideLengthDistance", value); }
        }

        public float RatingExcitement
        {
            get { return Get<float>("ratingExcitement"); }
            set { Set("ratingExcitement", value); }
        }

        public float RatingIntensity
        {
            get { return Get<float>("ratingIntensity"); }
            set { Set("ratingIntensity", value); }
        }

        public float RatingNausea
        {
            get { return Get<float>("ratingNausea"); }
            set { Set("ratingNausea", value); }
        }

        public float AirTime
        {
            get { return Get<float>("airTime"); }
            set { Set("airTime", value); }
        }

        public float AverageVelocity
        {
            get { return Get<float>("averageVelocity"); }
            set { Set("averageVelocity", value); }
        }

        public int HeadChoppers
        {
            get { return Get<int>("headChoppers"); }
            set { Set("headChoppers", value); }
        }
    }
}