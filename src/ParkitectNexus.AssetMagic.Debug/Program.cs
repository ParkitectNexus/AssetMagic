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
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Newtonsoft.Json;
using ParkitectNexus.AssetMagic.Elements;
using ParkitectNexus.AssetMagic.Extractors;

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
            
            Console.WriteLine("drops: " + blueprint.Coaster.Statistics.Drops);
            Console.WriteLine("drops: " + blueprint.Coaster.Statistics.Drops);

            blueprint.Coaster.Position = blueprint.Coaster.Position;
            Console.WriteLine(blueprint.Coaster.Position);

            Console.WriteLine(blueprint.Header);
            Console.WriteLine(blueprint.Coaster);

            Console.WriteLine("Data unchanged: " +(data == blueprint.ToString()));
            
            Console.ReadLine();
        }
    }
}