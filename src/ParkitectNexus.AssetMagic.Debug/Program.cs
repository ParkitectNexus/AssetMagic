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
using System.IO;
using ParkitectNexus.AssetMagic.Extractors;

namespace ParkitectNexus.AssetMagic.Debug
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var blueprintExtractor = new BlueprintExtractor();
            var savegameExtractor = new SavegameExtractor();

            Blueprint blueprint;
            using (var image = (Bitmap) Image.FromFile(@"..\..\..\..\tests\blueprints\fire-vortex-arrow.png"))
                blueprint = blueprintExtractor.Extract(image) as Blueprint;

            var savegame =
                savegameExtractor.Extract(File.ReadAllText(@"..\..\..\..\tests\parks\unnamed-park.txt"));

            Console.WriteLine("BLUEPRINT:");
            Console.WriteLine("Name: " + blueprint.Header.Name);

            Console.WriteLine("SAVEGAME:");
            Console.WriteLine("Name: " + savegame.Header.Name);
            Console.WriteLine("GuestCount: " + savegame.GuestCount);

            Console.ReadLine();
        }
    }
}