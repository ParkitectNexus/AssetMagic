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
    public class Guest : DataObject, IGuest
    {
        public Guest()
        {
        }

        public Guest(IDictionary<string, object> data) : base(data)
        {
        }

        #region Implementation of IGuest

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

        public virtual object C
        {
            get { return Get<object>("@c"); }
            set { Set("@c", value); }
        }

        public virtual int TilesWalked
        {
            get { return Get<int>("tilesWalked"); }
            set { Set("tilesWalked", value); }
        }

        public virtual int GuestNumber
        {
            get { return Get<int>("guestNumber"); }
            set { Set("guestNumber", value); }
        }

        public virtual float MoneySpent
        {
            get { return Get<float>("moneySpent"); }
            set { Set("moneySpent", value); }
        }

        public virtual int ParkEnterTime
        {
            get { return Get<int>("parkEnterTime"); }
            set { Set("parkEnterTime", value); }
        }

        public virtual float Happiness
        {
            get { return Get<float>("Happiness"); }
            set { Set("Happiness", value); }
        }

        public virtual float Tiredness
        {
            get { return Get<float>("Tiredness"); }
            set { Set("Tiredness", value); }
        }

        public virtual float Hunger
        {
            get { return Get<float>("Hunger"); }
            set { Set("Hunger", value); }
        }

        public virtual float Thirst
        {
            get { return Get<float>("Thirst"); }
            set { Set("Thirst", value); }
        }

        public virtual float ToiletUrgency
        {
            get { return Get<float>("ToiletUrgency"); }
            set { Set("ToiletUrgency", value); }
        }

        public virtual float Nausea
        {
            get { return Get<float>("Nausea"); }
            set { Set("Nausea", value); }
        }

        public virtual float NauseaTolerance
        {
            get { return Get<float>("NauseaTolerance"); }
            set { Set("NauseaTolerance", value); }
        }

        public virtual float SugarBoost
        {
            get { return Get<float>("SugarBoost"); }
            set { Set("SugarBoost", value); }
        }

        public virtual float Money
        {
            get { return Get<float>("Money"); }
            set { Set("Money", value); }
        }

        public virtual float MinIntensity
        {
            get { return Get<float>("MinIntensity"); }
            set { Set("MinIntensity", value); }
        }

        public virtual float MaxIntensity
        {
            get { return Get<float>("MaxIntensity"); }
            set { Set("MaxIntensity", value); }
        }

        public virtual float Patience
        {
            get { return Get<float>("Patience"); }
            set { Set("Patience", value); }
        }

        public virtual float Grumpiness
        {
            get { return Get<float>("Grumpiness"); }
            set { Set("Grumpiness", value); }
        }

        public virtual float Tidiness
        {
            get { return Get<float>("Tidiness"); }
            set { Set("Tidiness", value); }
        }

        public virtual float Generosity
        {
            get { return Get<float>("Generosity"); }
            set { Set("Generosity", value); }
        }

        public virtual int SpawnedAtTime
        {
            get { return Get<int>("spawnedAtTime"); }
            set { Set("spawnedAtTime", value); }
        }

        public virtual float DirtEncountered
        {
            get { return Get<float>("dirtEncountered"); }
            set { Set("dirtEncountered", value); }
        }

        public virtual float ParkEntranceFeePaid
        {
            get { return Get<float>("parkEntranceFeePaid"); }
            set { Set("parkEntranceFeePaid", value); }
        }

        public virtual float LastMoneySpentTime
        {
            get { return Get<float>("lastMoneySpentTime"); }
            set { Set("lastMoneySpentTime", value); }
        }

        public virtual float TiredStartTime
        {
            get { return Get<float>("tiredStartTime"); }
            set { Set("tiredStartTime", value); }
        }

        public virtual float AngryStartTime
        {
            get { return Get<float>("angryStartTime"); }
            set { Set("angryStartTime", value); }
        }

        public virtual float PriceSatisfactionSum
        {
            get { return Get<float>("priceSatisfactionSum"); }
            set { Set("priceSatisfactionSum", value); }
        }

        public virtual int PriceSatisfactionCount
        {
            get { return Get<int>("priceSatisfactionCount"); }
            set { Set("priceSatisfactionCount", value); }
        }

        public virtual float HappinessBeforeEnteringAttraction
        {
            get { return Get<float>("happinessBeforeEnteringAttraction"); }
            set { Set("happinessBeforeEnteringAttraction", value); }
        }

        public virtual object ExperienceLog
        {
            get { return Get<object>("experienceLog"); }
            set { Set("experienceLog", value); }
        }

        public virtual string Forename
        {
            get { return Get<string>("forename"); }
            set { Set("forename", value); }
        }

        public virtual string Surname
        {
            get { return Get<string>("surname"); }
            set { Set("surname", value); }
        }

        public virtual string Nickname
        {
            get { return Get<string>("nickname"); }
            set { Set("nickname", value); }
        }

        public virtual int Seed
        {
            get { return Get<int>("seed"); }
            set { Set("seed", value); }
        }

        public virtual string Gender
        {
            get { return Get<string>("gender"); }
            set { Set("gender", value); }
        }

        public virtual int Headstyle
        {
            get { return Get<int>("headstyle"); }
            set { Set("headstyle", value); }
        }

        public virtual int Torsostyle
        {
            get { return Get<int>("torsostyle"); }
            set { Set("torsostyle", value); }
        }

        public virtual int Legsstyle
        {
            get { return Get<int>("legsstyle"); }
            set { Set("legsstyle", value); }
        }

        public virtual int Hairstyle
        {
            get { return Get<int>("hairstyle"); }
            set { Set("hairstyle", value); }
        }

        public virtual int Eyesstyle
        {
            get { return Get<int>("eyesstyle"); }
            set { Set("eyesstyle", value); }
        }

        public virtual int Browsstyle
        {
            get { return Get<int>("browsstyle"); }
            set { Set("browsstyle", value); }
        }

        public virtual int UniqueID
        {
            get { return Get<int>("uniqueID"); }
            set { Set("uniqueID", value); }
        }

        public virtual bool TriggerExperienceNotifications
        {
            get { return Get<bool>("triggerExperienceNotifications"); }
            set { Set("triggerExperienceNotifications", value); }
        }

        public virtual object Behaviour
        {
            get { return Get<object>("behaviour"); }
            set { Set("behaviour", value); }
        }

        public virtual int[] Inventory
        {
            get { return GetArray<int>("inventory"); }
            set { Set("inventory", value); }
        }

        #endregion
    }
}