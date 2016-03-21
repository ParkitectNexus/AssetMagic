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
using ParkitectNexus.AssetMagic.Converters;

namespace ParkitectNexus.AssetMagic.Debug
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var bp = BlueprintConverter.DeserializeFromFile(@"..\..\..\..\tests\blueprints\test.png");

            Console.WriteLine($"Blueprint: {bp.Header.Name}");
            Console.WriteLine($"Content type: {bp.Header.ContentType}");
            Console.WriteLine($"Date: {bp.Header.Date}");
            Console.WriteLine($"GameVersion: {bp.Header.GameVersion}");
            Console.WriteLine($"GameVersionName: {bp.Header.GameVersionName}");
            Console.WriteLine($"SavegameVersion: {bp.Header.SavegameVersion}");
            Console.WriteLine($"Type: {bp.Header.Type}");
            Console.ReadLine();
        }
    }
}