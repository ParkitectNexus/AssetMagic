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

namespace ParkitectNexus.AssetMagic
{
    public class BlueprintExtractor : IBlueprintExtractor
    {
        #region Implementation of IBlueprintExtractor

        public IBlueprint Extract(Bitmap image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));
            if (image.Width != 512 || image.Height != 512)
                throw new Exception("invalid image");

            var data = ReadBytesUnsafeFromBlueprint(image).ToArray();

            if (data.Length != (512*512)/2 || data[0] != 0x53 || data[1] != 0x4D)
                throw new Exception("invalid image");

            var ver = data[2];
            var len = BitConverter.ToInt32(data, 3);

            if (len < 0 || len >= data.Length - 23)
                throw new Exception("invalid image");

            if (ver != 1)
                throw new Exception("unsupported version");

            var md5 = MD5.Create();
            var hash = md5.ComputeHash(data, 23, len);

            if (!hash.SequenceEqual(data.Skip(7).Take(16)))
                throw new Exception("invalid image");

            using (var memoryStream = new MemoryStream())
            {
                using (
                    var gZipStream = new GZipStream(new MemoryStream(data, 23, len, false), CompressionMode.Decompress))
                {
                    gZipStream.CopyTo(memoryStream);
                }
                var str = Encoding.UTF8.GetString(memoryStream.ToArray());
                return new Blueprint(ver, str);
            }
        }

        #endregion

        private static IEnumerable<byte> ReadBytesUnsafeFromBlueprint(Bitmap blueprint)
        {
            if (blueprint == null) throw new ArgumentNullException(nameof(blueprint));
            if (blueprint.Width != 512 || blueprint.Height != 512)
                throw new ArgumentException("invalid image", nameof(blueprint));

            var swap = false;
            byte keep = 0;
            for (var y = 0; y < blueprint.Height; y++)
                for (var x = 0; x < blueprint.Width; x++)
                {
                    var pixel = blueprint.GetPixel(x, y);
                    var r = pixel.R & 1;
                    var g = pixel.G & 1;
                    var b = pixel.B & 1;
                    var a = pixel.A & 1;

                    var part = (byte) ((a << 3) | (b << 2) | (g << 1) | r);

                    if (swap)
                        yield return (byte) ((part << 4) | keep);
                    else
                        keep = part;

                    swap = !swap;
                }
        }
    }
}