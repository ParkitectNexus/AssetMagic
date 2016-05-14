// ParkitectNexus.AssetMagic
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
    public class Guest : DataWrapper
    {
        [WrapProperty]
        public virtual long Id { get; set; }

        [WrapProperty]
        public virtual double[] Position { get; set; }

        [WrapProperty]
        public virtual double[] Rotation { get; set; }

        //        [Data("@c")]
        //        public virtual object C { get; set; }

        [WrapProperty]
        public virtual long TilesWalked { get; set; }

        [WrapProperty]
        public virtual long GuestNumber { get; set; }

        [WrapProperty]
        public virtual double MoneySpent { get; set; }

        [WrapProperty]
        public virtual long ParkEnterTime { get; set; }

        [WrapProperty]
        public virtual double Happiness { get; set; }

        [WrapProperty]
        public virtual double Tiredness { get; set; }

        [WrapProperty]
        public virtual double Hunger { get; set; }

        [WrapProperty]
        public virtual double Thirst { get; set; }

        [WrapProperty]
        public virtual double ToiletUrgency { get; set; }

        [WrapProperty]
        public virtual double Nausea { get; set; }

        [WrapProperty]
        public virtual double NauseaTolerance { get; set; }

        [WrapProperty]
        public virtual double SugarBoost { get; set; }

        [WrapProperty]
        public virtual double Money { get; set; }

        [WrapProperty]
        public virtual double MinIntensity { get; set; }

        [WrapProperty]
        public virtual double MaxIntensity { get; set; }

        [WrapProperty]
        public virtual double Patience { get; set; }

        [WrapProperty]
        public virtual double Grumpiness { get; set; }

        [WrapProperty]
        public virtual double Tidiness { get; set; }

        [WrapProperty]
        public virtual double Generosity { get; set; }

        [WrapProperty]
        public virtual long SpawnedAtTime { get; set; }

        [WrapProperty]
        public virtual double DirtEncountered { get; set; }

        [WrapProperty]
        public virtual double ParkEntranceFeePaid { get; set; }

        [WrapProperty]
        public virtual double LastMoneySpentTime { get; set; }

        [WrapProperty]
        public virtual double TiredStartTime { get; set; }

        [WrapProperty]
        public virtual double AngryStartTime { get; set; }

        [WrapProperty]
        public virtual double PriceSatisfactionSum { get; set; }

        [WrapProperty]
        public virtual long PriceSatisfactionCount { get; set; }

        [WrapProperty]
        public virtual double HappinessBeforeEnteringAttraction { get; set; }

        //        public virtual object ExperienceLog { get; set; }

        [WrapProperty]
        public virtual string Forename { get; set; }

        [WrapProperty]
        public virtual string Surname { get; set; }

        [WrapProperty]
        public virtual string Nickname { get; set; }

        [WrapProperty]
        public virtual long Seed { get; set; }

        [WrapProperty]
        public virtual string Gender { get; set; }

        [WrapProperty]
        public virtual long Headstyle { get; set; }

        [WrapProperty]
        public virtual long Torsostyle { get; set; }

        [WrapProperty]
        public virtual long Legsstyle { get; set; }

        [WrapProperty]
        public virtual long Hairstyle { get; set; }

        [WrapProperty]
        public virtual long Eyesstyle { get; set; }

        [WrapProperty]
        public virtual long Browsstyle { get; set; }

        [WrapProperty]
        public virtual long UniqueID { get; set; }

        [WrapProperty]
        public virtual bool TriggerExperienceNotifications { get; set; }

        //        public virtual object Behaviour { get; set; }

        [WrapProperty]
        public virtual long[] Inventory { get; set; }
    }
}