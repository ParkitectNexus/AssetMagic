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
        public int Id { get; set; }

        public float[] Position { get; set; }

        public float[] Rotation { get; set; }

//        [Data("@c")]
//        public object C { get; set; }

        public int TilesWalked { get; set; }

        public int GuestNumber { get; set; }

        public float MoneySpent { get; set; }

        public int ParkEnterTime { get; set; }

        public float Happiness { get; set; }

        public float Tiredness { get; set; }

        public float Hunger { get; set; }

        public float Thirst { get; set; }

        public float ToiletUrgency { get; set; }

        public float Nausea { get; set; }

        public float NauseaTolerance { get; set; }

        public float SugarBoost { get; set; }

        public float Money { get; set; }

        public float MinIntensity { get; set; }

        public float MaxIntensity { get; set; }

        public float Patience { get; set; }

        public float Grumpiness { get; set; }

        public float Tidiness { get; set; }

        public float Generosity { get; set; }

        public int SpawnedAtTime { get; set; }

        public float DirtEncountered { get; set; }

        public float ParkEntranceFeePaid { get; set; }

        public float LastMoneySpentTime { get; set; }

        public float TiredStartTime { get; set; }

        public float AngryStartTime { get; set; }

        public float PriceSatisfactionSum { get; set; }

        public int PriceSatisfactionCount { get; set; }

        public float HappinessBeforeEnteringAttraction { get; set; }

//        public object ExperienceLog { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public int Seed { get; set; }

        public string Gender { get; set; }

        public int Headstyle { get; set; }

        public int Torsostyle { get; set; }

        public int Legsstyle { get; set; }

        public int Hairstyle { get; set; }

        public int Eyesstyle { get; set; }

        public int Browsstyle { get; set; }

        public int UniqueID { get; set; }

        public bool TriggerExperienceNotifications { get; set; }

//        public object Behaviour { get; set; }

        public int[] Inventory { get; set; }
    }
}