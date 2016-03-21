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
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ParkitectNexus.AssetMagic.Data;
using ParkitectNexus.AssetMagic.JsonConverters;
using ParkitectNexus.AssetMagic.Streams;
using ParkitectNexus.AssetMagic.Utilities;

namespace ParkitectNexus.AssetMagic.Converters
{
    public static class BlueprintConverter
    {
        public static IBlueprint DeserializeFromFile(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            return Deserialize(ReadFromImage(Image.FromFile(path)));
        }

        public static IBlueprint Deserialize(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            return Deserialize(ReadFromImage(Image.FromStream(stream)));
        }

        public static IBlueprint Deserialize(string data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            var blueprint = new Blueprint(data.GetFilledLines().Select(DataElement.Parse).ToArray());

            if (blueprint.Header == null)
                throw new InvalidBlueprintException("BlueprintHeader is missing");

            return blueprint;
        }

        public static IBlueprint Deserialize(Image image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));
            return Deserialize(ReadFromImage(image));
        }

        public static void SerializeToFile(IBlueprint blueprint, Image image, string path)
        {
            if (blueprint == null) throw new ArgumentNullException(nameof(blueprint));
            if (image == null) throw new ArgumentNullException(nameof(image));
            if (path == null) throw new ArgumentNullException(nameof(path));
            using (var stream = File.OpenWrite(path))
                SerializeToStream(blueprint, image, stream);
        }

        public static string SerializeToString(IBlueprint blueprint)
        {
            if (blueprint == null) throw new ArgumentNullException(nameof(blueprint));

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new MiniJsonContractResolver(),
                Converters = new[] {new MiniJsonFloatConverter()}
            };
            return string.Concat(blueprint.Data.Select(d => JsonConvert.SerializeObject(d.Data, settings) + "\r\n"));
        }

        public static void SerializeToStream(IBlueprint blueprint, Image image, Stream stream)
        {
            if (blueprint == null) throw new ArgumentNullException(nameof(blueprint));
            if (image == null) throw new ArgumentNullException(nameof(image));
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            using (var img = new Bitmap(image))
            {
                WriteToImage(SerializeToString(blueprint), img);
                img.Save(stream, ImageFormat.Png);
            }
        }

        public static string ReadFromImage(Image image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));
            using (var bdStream = new BitmapDataStream((Bitmap) image))
            using (var gZipStream = new GZipStream(bdStream, CompressionMode.Decompress))
            using (var memoryStream = new MemoryStream())
            {
                gZipStream.CopyTo(memoryStream);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        public static void WriteToImage(string data, Image image)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            if (image == null) throw new ArgumentNullException(nameof(image));
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            using (var bdStream = new BitmapDataStream((Bitmap) image))
            {
                bdStream.SetLength(0);
                using (var gZipStream = new GZipStream(bdStream, CompressionMode.Compress))
                    memoryStream.CopyTo(gZipStream);
            }
        }
    }
}