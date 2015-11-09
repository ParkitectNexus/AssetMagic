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

namespace ParkitectNexus.AssetMagic.Elements
{
    public interface ICoaster : IDataObject
    {
        int Id { get; set; }
        float[] Position { get; set; }
        float[] Rotation { get; set; }
        object CarColors { get; set; }
        object TrackColors { get; set; }
        int TrackId { get; set; }
        float EntranceFee { get; set; }
        float Duration { get; set; }
        ITrackedRideStats Statistics { get; set; }
        int TrainCount { get; set; }
        int TrainLength { get; set; }
        string CarType { get; set; }
        int WaitTime { get; set; }
        object StationControllers { get; set; }
    }
}