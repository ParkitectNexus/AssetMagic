namespace ParkitectNexus.AssetMagic
{
    [DataObjectName("(.*Coaster|.*Railway)")]
    public class Coaster : DataObject
    {
        public int Id
        {
            get { return Get<int>("@id"); }
            set { Set("@id", value); }
        }

        public float[] Position
        {
            get { return GetArray<float>("pos"); }
            set { Set("pos", value); }
        }

        public float[] Rotation
        {
            get { return GetArray<float>("rot"); }
            set { Set("rot", value); }
        }

        public float[] CarColors
        {
            get { return GetArray<float>("carColors"); }
            set { Set("carColors", value); }
        }

        public float[] TrackColors
        {
            get { return GetArray<float>("trackColors"); }
            set { Set("trackColors", value); }
        }

        public int TrackId
        {
            get { return Get<int>("Track"); }
            set { Set("Track", value); }
        }

        public float EntranceFee
        {
            get { return Get<float>("entranceFee"); }
            set { Set("entranceFee", value); }
        }

        public float Duration
        {
            get { return Get<float>("duration"); }
            set { Set("duration", value); }
        }

        public TrackedRideStats Statistics
        {
            get { return Get<TrackedRideStats>("stats"); }
            set { Set("stats", value); }
        }
        
        public int TrainCount
        {
            get { return Get<int>("trainCount"); }
            set { Set("trainCount", value); }
        }

        public int TrainLength
        {
            get { return Get<int>("trainLength"); }
            set { Set("trainLength", value); }
        }

        public string CarType
        {
            get { return Get<string>("carType"); }
            set { Set("carType", value); }
        }

        public int WaitTime
        {
            get { return Get<int>("waitTime"); }
            set { Set("waitTime", value); }
        }

        public object StationControllers
        {
            get { return Get<object>("stationControllers"); }
            set { Set("stationControllers", value); }
        }

        //"stationControllers":[{"@type":"TrackedRideStationController","@id":"3","attraction":"1","entrance":"4","exit":"5"}]}
    }
}