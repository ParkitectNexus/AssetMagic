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
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace ParkitectNexus.AssetMagic
{
    public class BlueprintExtractor : IBlueprintExtractor
    {
        private const int OffsetHeader = 0;
        private const int OffsetVersion = 2;
        private const int OffsetLength = 3;
        private const int OffsetChecksum = 7;
        private const int OffsetData = 23;

        private static readonly byte[] Header = {0x53, 0x4D};

        #region Implementation of IBlueprintExtractor

        public IBlueprint Extract(Bitmap image)
        {
            byte version;
            var data = ExtractData(image, out version);

            return new Blueprint(version, data);
        }

        public string ExtractData(Bitmap image)
        {
            byte tmp;
            return ExtractData(image, out tmp);
        }

        public string ExtractData(Bitmap image, out byte version)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));

            var data = ReadDataFromLeastSignificantBit(image).ToArray();

            if (data.Length != (image.Width * image.Height) / 2 ||
                !data.Skip(OffsetHeader).Take(Header.Length).SequenceEqual(Header))
                throw new InvalidBlueprintException("invalid header");

            version = data.ElementAt(OffsetVersion);
            var length = BitConverter.ToInt32(data, OffsetLength);

            if (length < 0 || length >= data.Length - OffsetData)
                throw new InvalidBlueprintException("invalid length");
            
            var md5 = MD5.Create();
            var checksum = md5.ComputeHash(data, OffsetData, length);

            if (!checksum.SequenceEqual(data.Skip(OffsetChecksum).Take(16)))
                throw new InvalidBlueprintException("data corrupted");

            using (var memoryStream = new MemoryStream())
            {
                using (
                    var gZipStream = new GZipStream(new MemoryStream(data, OffsetData, length, false),
                        CompressionMode.Decompress))
                    gZipStream.CopyTo(memoryStream);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        #endregion

        private static IEnumerable<byte> ReadDataFromLeastSignificantBit(Bitmap image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));

            var swap = false;
            byte memory = 0;

            for (var y = 0; y < image.Height; y++)
                for (var x = 0; x < image.Width; x++)
                {
                    var pixel = image.GetPixel(x, y);

                    var r = pixel.R & 1;
                    var g = pixel.G & 1;
                    var b = pixel.B & 1;
                    var a = pixel.A & 1;

                    var nibble = (byte) ((a << 3) | (b << 2) | (g << 1) | r);

                    if (swap)
                        yield return (byte) ((nibble << 4) | memory);
                    else
                        memory = nibble;

                    swap = !swap;
                }
        }
    }
}