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
    public interface IGuest : IDataObject
    {
        int Id { get; set; }
        float[] Position { get; set; }
        float[] Rotation { get; set; }
        object C { get; set; }
        int TilesWalked { get; set; }
        int GuestNumber { get; set; }
        float MoneySpent { get; set; }
        int ParkEnterTime { get; set; }
        float Happiness { get; set; }
        float Tiredness { get; set; }
        float Hunger { get; set; }
        float Thirst { get; set; }
        float ToiletUrgency { get; set; }
        float Nausea { get; set; }
        float NauseaTolerance { get; set; }
        float SugarBoost { get; set; }
        float Money { get; set; }
        float MinIntensity { get; set; }
        float MaxIntensity { get; set; }
        float Patience { get; set; }
        float Grumpiness { get; set; }
        float Tidiness { get; set; }
        float Generosity { get; set; }
        int SpawnedAtTime { get; set; }
        float DirtEncountered { get; set; }
        float ParkEntranceFeePaid { get; set; }
        float LastMoneySpentTime { get; set; }
        float TiredStartTime { get; set; }
        float AngryStartTime { get; set; }
        float PriceSatisfactionSum { get; set; }
        int PriceSatisfactionCount { get; set; }
        float HappinessBeforeEnteringAttraction { get; set; }
        object ExperienceLog { get; set; }
        string Forename { get; set; }
        string Surname { get; set; }
        string Nickname { get; set; }
        int Seed { get; set; }
        string Gender { get; set; }
        int Headstyle { get; set; }
        int Torsostyle { get; set; }
        int Legsstyle { get; set; }
        int Hairstyle { get; set; }
        int Eyesstyle { get; set; }
        int Browsstyle { get; set; }
        int UniqueID { get; set; }
        bool TriggerExperienceNotifications { get; set; }
        object Behaviour { get; set; }
        int[] Inventory { get; set; }
    }
}