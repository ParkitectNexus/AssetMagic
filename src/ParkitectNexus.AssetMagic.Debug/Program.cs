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
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using ParkitectNexus.AssetMagic.Converters;
using ParkitectNexus.AssetMagic.Data;
using ParkitectNexus.AssetMagic.Data.Coasters;

namespace ParkitectNexus.AssetMagic.Debug
{
    internal class Program
    {
        private static string Join(params string[] values)
        {
            if (values == null)
                return string.Empty;

            return string.Join(", ", values);
        }
        private static void Main(string[] args)
        {
            Console.WriteLine("\n\nBLUEPRINTS:");

            var path = @"..\..\..\..\tests\blueprints\shipwreck-cove.png";
            var bp = BlueprintConverter.DeserializeFromFile(path);
            var str =BlueprintConverter.SerializeToString(bp);
            Console.WriteLine(str);
            var coaster = bp.Coasters.FirstOrDefault();
            var h = bp.Header;
            Console.WriteLine(h.GameVersion);
            Console.WriteLine(h.GameVersionName);
            var stats = coaster?.Stats;
            Console.WriteLine(stats?.MaxLatG);
            Console.WriteLine(stats?.MaxLongG);
            Console.WriteLine(coaster?.TrainCount);

//            Console.WriteLine(BlueprintConverter.ReadFromImage(Image.FromFile(path)));
//            Console.ReadLine();

//            Console.WriteLine("Rewriting to same content? {0}",
//                BlueprintConverter.SerializeToString(bp) == BlueprintConverter.ReadFromImage(Image.FromFile(path)));

//            PrintUnmappedProperties(bp.Header);
            
//            Console.WriteLine($"Blueprint: {bp.Header.Name}");
//            Console.WriteLine($"Date: {bp.Header.Date}");
//            Console.WriteLine($"GameVersion: {bp.Header.GameVersion}");
//            Console.WriteLine($"GameVersionName: {bp.Header.GameVersionName}");
//            Console.WriteLine($"SavegameVersion: {bp.Header.SavegameVersion}");
//            Console.WriteLine($"Type: {bp.Header.Type}");
//            Console.WriteLine($"ApproximateCost: {bp.Header.ApproximateCost}");
//            Console.WriteLine($"Types: [{Join(bp.Header.Types)}]");
//            Console.WriteLine($"DecoTypes: [{Join(bp.Header.DecoTypes)}]");
//            Console.WriteLine($"FlatRideTypes: [{Join( bp.Header.FlatRideTypes)}]");
//            Console.WriteLine($"TrackedRideTypes: [{Join(bp.Header.TrackedRideTypes)}]");
            //Console.WriteLine($"Coaster.Type: {bp.GetElement<Coaster>()?.Type}");
//            Console.WriteLine("\n\nSAVEGAMES:");
            //var path2 = @"..\..\..\..\tests\parks\compressed.park";
//            var path2 = @"..\..\..\..\tests\parks\unnamed-park.txt";
//            var sg = SavegameConverter.DeserializeFromFile(path2);

//            byte[] bytes;
//            using (var ms = new MemoryStream())
//            {
//                SavegameConverter.SerializeToStream(sg, ms);
//                bytes = ms.ToArray();
//            }
//
////            SavegameConverter.SerializeToFile(sg, path2.Replace(".park", "back.park"));
//            Console.WriteLine("Rewriting to same content? {0}", bytes.SequenceEqual(File.ReadAllBytes(path2)));

//            PrintUnmappedProperties(sg.Header);
//            PrintUnmappedProperties(sg.Park);

            Console.ReadLine();
        }

        private static void PrintUnmappedProperties(DataWrapper wrapper)
        {
//            var u = wrapper.GetUnmappedProperties();
//
//            if (u.Any())
//            {
//                Console.WriteLine($"UNMAPPED PROPERTIES IN {wrapper.GetType()}");
//
//                foreach (var p in u)
//                    Console.WriteLine($">>> {p} ({wrapper[p].GetType()})");
//
//                Console.WriteLine();
//            }
        }
    }
}