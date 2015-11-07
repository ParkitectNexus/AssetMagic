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
    public interface ITrackedRideStats
    {
        float MinVertG { get; set; }
        float MaxVertG { get; set; }
        float MinLatG { get; set; }
        float MaxLatG { get; set; }
        float AverageLatG { get; set; }
        float MinLongG { get; set; }
        float MaxLongG { get; set; }
        float MaxVelocity { get; set; }
        float MaxVelocityT { get; set; }
        int DirectionChanges { get; set; }
        int Drops { get; set; }
        float TotalDropHeight { get; set; }
        float BiggestDrop { get; set; }
        float BiggestDropStartT { get; set; }
        int Inversions { get; set; }
        float RideLengthTime { get; set; }
        float RideLengthDistance { get; set; }
        float RatingExcitement { get; set; }
        float RatingIntensity { get; set; }
        float RatingNausea { get; set; }
        float AirTime { get; set; }
        float AverageVelocity { get; set; }
        int HeadChoppers { get; set; }
    }
}