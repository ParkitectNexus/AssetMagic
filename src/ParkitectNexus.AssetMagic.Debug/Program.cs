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

using System;
using System.Drawing;

namespace ParkitectNexus.AssetMagic.Debug
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var extractor = new BlueprintExtractor();

            string data;
            Blueprint blueprint;

            using (var image = (Bitmap) Image.FromFile(@"..\..\..\..\tests\blueprints\fire-vortex-arrow.png"))
            {
                data = extractor.ExtractData(image);
                blueprint = extractor.Extract(image) as Blueprint;
            }

            Console.WriteLine("Name: " + blueprint.Header.Name);
            Console.WriteLine("Date: " + blueprint.Header.Date);
            Console.WriteLine("GameVersion: " + blueprint.Header.GameVersion);
            Console.WriteLine("GameVersionName: " + blueprint.Header.GameVersionName);
            Console.WriteLine("SavegameVersion: " + blueprint.Header.SavegameVersion);
            Console.WriteLine("Version: " + blueprint.Version);
            Console.WriteLine("Type: " + blueprint.Header.Type);
            
            blueprint.Header.Name = "Fire Vortex";
            blueprint.Header.Date = blueprint.Header.Date;
            blueprint.Header.GameVersion = 3;
            blueprint.Header.GameVersionName = "Pre-Alpha 4a";
            blueprint.Header.SavegameVersion = 8;
            blueprint.Header.Type = "SteelCoaster";

            Console.WriteLine(blueprint.ToString()==data);
            Console.ReadLine();
        }
    }
}