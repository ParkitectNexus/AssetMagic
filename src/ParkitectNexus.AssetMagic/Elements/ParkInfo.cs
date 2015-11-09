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
    public class ParkInfo : DataObject, IParkInfo
    {
        public ParkInfo()
        {
        }

        public ParkInfo(IDictionary<string, object> data) : base(data)
        {
            
        }

        #region Implementation of IParkInfo
        
        public virtual int Time
        {
            get { return Get<int>("time"); }
            set { Set("time", value); }
        }

        public virtual float Money
        {
            get { return Get<float>("money"); }
            set { Set("money", value); }
        }

        public virtual int GuestsLeftCount
        {
            get { return Get<int>("guestsLeftCount"); }
            set { Set("guestsLeftCount", value); }
        }

        public virtual float ParkEntranceFee
        {
            get { return Get<float>("parkEntranceFee"); }
            set { Set("parkEntranceFee", value); }
        }

        public virtual float RatingPriceSatisfaction
        {
            get { return Get<float>("ratingPriceSatisfaction"); }
            set { Set("ratingPriceSatisfaction", value); }
        }

        public virtual float RatingCleanliness
        {
            get { return Get<float>("ratingCleanliness"); }
            set { Set("ratingCleanliness", value); }
        }

        public virtual float RatingHappiness
        {
            get { return Get<float>("ratingHappiness"); }
            set { Set("ratingHappiness", value); }
        }

        public virtual string Transactions
        {
            get { return Get<string>("transactions"); }
            set { Set("transactions", value); }
        }
    }

    #endregion
}