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
    public class ParkInfo : DataObject, IParkInfo
    {
        #region Implementation of IParkInfo

        public int Time
        {
            get { return Get<int>("time"); }
            set { Set("time", value); }
        }

        public float Money
        {
            get { return Get<float>("money"); }
            set { Set("money", value); }
        }

        public int GuestsLeftCount
        {
            get { return Get<int>("guestsLeftCount"); }
            set { Set("guestsLeftCount", value); }
        }

        public float ParkEntranceFee
        {
            get { return Get<float>("parkEntranceFee"); }
            set { Set("parkEntranceFee", value); }
        }

        public float RatingPriceSatisfaction
        {
            get { return Get<float>("ratingPriceSatisfaction"); }
            set { Set("ratingPriceSatisfaction", value); }
        }

        public float RatingCleanliness
        {
            get { return Get<float>("ratingCleanliness"); }
            set { Set("ratingCleanliness", value); }
        }

        public float RatingHappiness
        {
            get { return Get<float>("ratingHappiness"); }
            set { Set("ratingHappiness", value); }
        }

        public string Transactions
        {
            get { return Get<string>("transactions"); }
            set { Set("transactions", value); }
        }
    }

    #endregion
}