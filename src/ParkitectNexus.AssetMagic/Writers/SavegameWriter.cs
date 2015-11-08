using System;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ParkitectNexus.AssetMagic.JsonConverters;

namespace ParkitectNexus.AssetMagic.Writers
{
    public class SavegameWriter : ISavegameWriter
    {
        #region Implementation of IBlueprintWriter

        public string Serialize(ISavegame savegame)
        {
            if (savegame == null) throw new ArgumentNullException(nameof(savegame));

            var settings = new JsonSerializerSettings
            {
                ContractResolver = new MiniJsonContractResolver(),
                Converters = new[] { new MiniJsonFloatConverter() }
            };

            return string.Concat(savegame.Data.Select(d => JsonConvert.SerializeObject(d, settings) + "\r\n"));
        }

        public void Serialize(ISavegame savegame, Stream stream)
        {
            if (savegame == null) throw new ArgumentNullException(nameof(savegame));
            if (stream == null) throw new ArgumentNullException(nameof(stream));

            using (var streamWriter = new StreamWriter(stream))
                streamWriter.Write(Serialize(savegame));
        }

        #endregion
    }
}