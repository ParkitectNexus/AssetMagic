﻿// ParkitectNexus.AssetMagic
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

namespace ParkitectNexus.AssetMagic.Data.Savegames
{
    public class ParkInfo : DataWrapper
    {
        [WrapProperty]
        public virtual double Money { get; set; }

        [WrapProperty]
        public virtual long GuestsLeftCount { get; set; }

        [WrapProperty]
        public virtual double ParkEntranceFee { get; set; }

        [WrapProperty]
        public virtual double RatingPriceSatisfaction { get; set; }

        [WrapProperty]
        public virtual double RatingCleanliness { get; set; }

        [WrapProperty]
        public virtual double RatingHappiness { get; set; }

        [WrapProperty]
        public virtual string Transactions { get; set; }
    }
}