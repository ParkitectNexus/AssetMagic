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
using Newtonsoft.Json;
using ParkitectNexus.AssetMagic.JsonConverters;
using ParkitectNexus.AssetMagic.Streams;

namespace ParkitectNexus.AssetMagic.Writers
{
    public class BlueprintWriter : IBlueprintWriter
    {
        #region Implementation of IBlueprintWriter

        public virtual string Serialize(IBlueprint blueprint)
        {
            if (blueprint == null) throw new ArgumentNullException(nameof(blueprint));

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new MiniJsonContractResolver(),
                Converters = new[] {new MiniJsonFloatConverter()}
            };

            return string.Concat(blueprint.Data.Select(d => JsonConvert.SerializeObject(d.Data, settings) + "\r\n"));
        }

        public virtual void Serialize(IBlueprint blueprint, Stream destinationStream)
        {
            if (blueprint == null) throw new ArgumentNullException(nameof(blueprint));
            if (destinationStream == null) throw new ArgumentNullException(nameof(destinationStream));

            using (var streamWriter = new StreamWriter(destinationStream))
                streamWriter.Write(Serialize(blueprint));
        }

        public virtual void Write(IBlueprint blueprint, Bitmap destinationImage)
        {
            WriteData(Serialize(blueprint), destinationImage);
        }

        public virtual void WriteData(string data, Bitmap destinationBitmap)
        {
            using (var memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(data)))
            using (var bdStream = new BitmapDataStream(destinationBitmap))
            {
                bdStream.SetLength(0);
                using (var gZipStream = new GZipStream(bdStream, CompressionMode.Compress))
                    memoryStream.CopyTo(gZipStream);
            }
        }

        #endregion
    }
}