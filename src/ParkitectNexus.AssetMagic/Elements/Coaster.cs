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

using ParkitectNexus.AssetMagic.Attributes;

namespace ParkitectNexus.AssetMagic.Elements
{
    [DataObjectName("(.*Coaster|.*Railway)")]
    public class Coaster : DataObject, ICoaster
    {
        #region Implementation of ICoaster

        public virtual int Id
        {
            get { return Get<int>("@id"); }
            set { Set("@id", value); }
        }

        public virtual float[] Position
        {
            get { return GetArray<float>("pos"); }
            set { Set("pos", value); }
        }

        public virtual float[] Rotation
        {
            get { return GetArray<float>("rot"); }
            set { Set("rot", value); }
        }

        public virtual float[] CarColors
        {
            get { return GetArray<float>("carColors"); }
            set { Set("carColors", value); }
        }

        public virtual float[] TrackColors
        {
            get { return GetArray<float>("trackColors"); }
            set { Set("trackColors", value); }
        }

        public virtual int TrackId
        {
            get { return Get<int>("Track"); }
            set { Set("Track", value); }
        }

        public virtual float EntranceFee
        {
            get { return Get<float>("entranceFee"); }
            set { Set("entranceFee", value); }
        }

        public virtual float Duration
        {
            get { return Get<float>("duration"); }
            set { Set("duration", value); }
        }

        public virtual ITrackedRideStats Statistics
        {
            get { return Get<TrackedRideStats>("stats"); }
            set { Set("stats", value); }
        }

        public virtual int TrainCount
        {
            get { return Get<int>("trainCount"); }
            set { Set("trainCount", value); }
        }

        public virtual int TrainLength
        {
            get { return Get<int>("trainLength"); }
            set { Set("trainLength", value); }
        }

        public virtual string CarType
        {
            get { return Get<string>("carType"); }
            set { Set("carType", value); }
        }

        public virtual int WaitTime
        {
            get { return Get<int>("waitTime"); }
            set { Set("waitTime", value); }
        }

        public virtual object StationControllers
        {
            get { return Get<object>("stationControllers"); }
            set { Set("stationControllers", value); }
        }

        //"stationControllers":[{"@type":"TrackedRideStationController","@id":"3","attraction":"1","entrance":"4","exit":"5"}]}

        #endregion
    }
}