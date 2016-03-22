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

namespace ParkitectNexus.AssetMagic.Data.Savegames
{
    public class Guest : DataElement
    {
        public long Id { get; set; }

        public double[] Position { get; set; }

        public double[] Rotation { get; set; }

//        [Data("@c")]
//        public object C { get; set; }

        public long TilesWalked { get; set; }

        public long GuestNumber { get; set; }

        public double MoneySpent { get; set; }

        public long ParkEnterTime { get; set; }

        public double Happiness { get; set; }

        public double Tiredness { get; set; }

        public double Hunger { get; set; }

        public double Thirst { get; set; }

        public double ToiletUrgency { get; set; }

        public double Nausea { get; set; }

        public double NauseaTolerance { get; set; }

        public double SugarBoost { get; set; }

        public double Money { get; set; }

        public double MinIntensity { get; set; }

        public double MaxIntensity { get; set; }

        public double Patience { get; set; }

        public double Grumpiness { get; set; }

        public double Tidiness { get; set; }

        public double Generosity { get; set; }

        public long SpawnedAtTime { get; set; }

        public double DirtEncountered { get; set; }

        public double ParkEntranceFeePaid { get; set; }

        public double LastMoneySpentTime { get; set; }

        public double TiredStartTime { get; set; }

        public double AngryStartTime { get; set; }

        public double PriceSatisfactionSum { get; set; }

        public long PriceSatisfactionCount { get; set; }

        public double HappinessBeforeEnteringAttraction { get; set; }

//        public object ExperienceLog { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public long Seed { get; set; }

        public string Gender { get; set; }

        public long Headstyle { get; set; }

        public long Torsostyle { get; set; }

        public long Legsstyle { get; set; }

        public long Hairstyle { get; set; }

        public long Eyesstyle { get; set; }

        public long Browsstyle { get; set; }

        public long UniqueID { get; set; }

        public bool TriggerExperienceNotifications { get; set; }

//        public object Behaviour { get; set; }

        public long[] Inventory { get; set; }
    }
}