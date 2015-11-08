﻿// ParkitectNexus.AssetMagic
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
    public interface IParkInfo : IDataObject
    {
        float Money { get; set; }
        int GuestsLeftCount { get; set; }
        float ParkEntranceFee { get; set; }
        float RatingPriceSatisfaction { get; set; }
        float RatingCleanliness { get; set; }
        float RatingHappiness { get; set; }
        string Transactions { get; set; }
    }
}