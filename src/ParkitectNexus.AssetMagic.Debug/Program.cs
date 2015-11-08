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
using System.Drawing.Imaging;
using System.IO;
using ParkitectNexus.AssetMagic.Readers;
using ParkitectNexus.AssetMagic.Writers;

namespace ParkitectNexus.AssetMagic.Debug
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var blueprintReader = new BlueprintReader();
            var savegameReader = new SavegameReader();
            var blueprintWriter = new BlueprintWriter();

            IBlueprint blueprint;
            using (var image = (Bitmap) Image.FromFile(@"..\..\..\..\tests\blueprints\fire-vortex-arrow.png"))
                blueprint = blueprintReader.Read(image);

            var savegame =
                savegameReader.Deserialize(File.ReadAllText(@"..\..\..\..\tests\parks\unnamed-park.txt"));

            var bmp = new Bitmap(512, 512);
            blueprintWriter.Write(blueprint, bmp);

            bmp.Save("C:/Users/Tim/Desktop/bmp.png", ImageFormat.Png);
            var blueprint2 = blueprintReader.Read(bmp);


            Console.WriteLine("BLUEPRINT:");
            Console.WriteLine("Name: " + blueprint.Header.Name);

            Console.WriteLine("BLUEPRINT2:");
            Console.WriteLine("Name: " + blueprint2.Header.Name);

            Console.WriteLine("SAVEGAME:");
            Console.WriteLine("Name: " + savegame.Header.Name);
            Console.WriteLine("GuestCount: " + savegame.GuestCount);

            Console.ReadLine();
        }
    }
}