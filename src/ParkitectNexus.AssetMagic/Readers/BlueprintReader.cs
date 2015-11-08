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
using System.IO.Compression;
using System.Linq;
using System.Text;
using ParkitectNexus.AssetMagic.Elements;
using ParkitectNexus.AssetMagic.Streams;
using ParkitectNexus.AssetMagic.Utilities;

namespace ParkitectNexus.AssetMagic.Readers
{
    public class BlueprintReader : IBlueprintReader
    {
        #region Implementation of IBlueprintReader

        public virtual IBlueprint Deserialize(string data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));

            var parser = new DataObjectParser(typeof (BlueprintHeader), typeof (Coaster));
            var blueprint = new Blueprint(data.GetFilledLines().Select(parser.Parse).ToArray());

            if (blueprint.Header == null)
                throw new InvalidBlueprintException("BlueprintHeader is missing");
            if (blueprint.Coaster == null)
                throw new InvalidBlueprintException("missing or unsupported coaster type");

            return blueprint;
        }

        public virtual IBlueprint Read(Bitmap image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));
            var data = ReadData(image);

            return Deserialize(data);
        }

        public virtual string ReadData(Bitmap image)
        {
            if (image == null) throw new ArgumentNullException(nameof(image));

            using (var bdStream = new BitmapDataStream(image))
            using (var gZipStream = new GZipStream(bdStream, CompressionMode.Decompress))
            using (var memoryStream = new MemoryStream())
            {
                gZipStream.CopyTo(memoryStream);
                return Encoding.UTF8.GetString(memoryStream.ToArray());
            }
        }

        #endregion
    }
}