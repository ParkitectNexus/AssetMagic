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
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using ParkitectNexus.AssetMagic.Data;
using ParkitectNexus.AssetMagic.JsonConverters;
using ParkitectNexus.AssetMagic.Utilities;

namespace ParkitectNexus.AssetMagic.Converters
{
    public static class SavegameConverter
    {
        public static ISavegame DeserializeFromFile(string path)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));
            return Deserialize(File.ReadAllText(path));
        }

        public static ISavegame Deserialize(Stream stream)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            if (stream is MemoryStream)
            {
                var memoryStream = stream as MemoryStream;
                return Deserialize(Encoding.UTF8.GetString(memoryStream.ToArray()));
            }

            using (var memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return Deserialize(Encoding.UTF8.GetString(memoryStream.ToArray()));
            }
        }

        public static ISavegame Deserialize(string data)
        {
            if (data == null) throw new ArgumentNullException(nameof(data));
            var savegame = new Savegame(data.GetFilledLines().Select(DataElement.Parse).ToArray());

            if (savegame.Header == null)
                throw new InvalidSavegameException("SavegameHeader is missing");
            if (savegame.Park == null)
                throw new InvalidSavegameException("Park is missing");

            return savegame;
        }

        public static void SerializeToFile(ISavegame savegame, string path)
        {
            if (savegame == null) throw new ArgumentNullException(nameof(savegame));
            if (path == null) throw new ArgumentNullException(nameof(path));
            File.WriteAllText(path, SerializeToString(savegame));
        }

        public static string SerializeToString(ISavegame savegame)
        {
            if (savegame == null) throw new ArgumentNullException(nameof(savegame));

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new MiniJsonContractResolver(),
                Converters = new[] {new MiniJsonFloatConverter()}
            };
            return string.Concat(savegame.Data.Select(d => JsonConvert.SerializeObject(d.Data, settings) + "\r\n"));
        }

        public static void SerializeToStream(ISavegame savegame, Stream stream)
        {
            if (savegame == null) throw new ArgumentNullException(nameof(savegame));
            if (stream == null) throw new ArgumentNullException(nameof(stream));
            using (var streamWriter = new StreamWriter(stream))
            {
                streamWriter.Write(SerializeToString(savegame));
            }
        }
    }
}