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

using System;
using System.Drawing;
using System.IO;
using System.Linq;
using ParkitectNexus.AssetMagic.Converters;
using ParkitectNexus.AssetMagic.Data;

namespace ParkitectNexus.AssetMagic.Debug
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("\n\nBLUEPRINTS:");

            var path = @"..\..\..\..\tests\blueprints\test-pa9.png";
            var bp = BlueprintConverter.DeserializeFromFile(path);

//            Console.WriteLine(BlueprintConverter.ReadFromImage(Image.FromFile(path)));
//            Console.ReadLine();

            Console.WriteLine("Rewriting to same content? {0}",
                BlueprintConverter.SerializeToString(bp) == BlueprintConverter.ReadFromImage(Image.FromFile(path)));

            PrintUnmappedProperties(bp.Header);
            
            Console.WriteLine($"Blueprint: {bp.Header.Name}");
            Console.WriteLine($"Date: {bp.Header.Date}");
            Console.WriteLine($"GameVersion: {bp.Header.GameVersion}");
            Console.WriteLine($"GameVersionName: {bp.Header.GameVersionName}");
            Console.WriteLine($"SavegameVersion: {bp.Header.SavegameVersion}");
            Console.WriteLine($"Type: {bp.Header.Type}");
            Console.WriteLine($"ApproximateCost: {bp.Header.ApproximateCost}");
            Console.WriteLine($"Types: [{string.Join(", ", bp.Header.Types)}]");
            Console.WriteLine($"DecoTypes: [{string.Join(", ", bp.Header.DecoTypes)}]");
            Console.WriteLine($"FlatRideTypes: [{string.Join(", ", bp.Header.FlatRideTypes)}]");
            Console.WriteLine($"TrackedRideTypes: [{string.Join(", ", bp.Header.TrackedRideTypes)}]");

            Console.WriteLine("\n\nSAVEGAMES:");

            var path2 = @"..\..\..\..\tests\parks\test-pa9.txt";
            var sg = SavegameConverter.DeserializeFromFile(path2);

            Console.WriteLine("Rewriting to same content? {0}",
                SavegameConverter.SerializeToString(sg) == File.ReadAllText(path2));

            PrintUnmappedProperties(sg.Header);
            PrintUnmappedProperties(sg.Park);

            Console.ReadLine();
        }

        private static void PrintUnmappedProperties(DataElement element)
        {
            var u = element.GetUnmappedProperties();

            if (u.Any())
            {
                Console.WriteLine($"UNMAPPED PROPERTIES IN {element.GetType()}");

                foreach (var p in u)
                    Console.WriteLine($">>> {p} ({element[p].GetType()})");

                Console.WriteLine();
            }
        }
    }
}