using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;

namespace ParkitectNexus.AssetMagic
{
    public class MiniJsonFloatConverter : JsonConverter
    {
        #region Overrides of JsonConverter

        /// <summary>
        /// Writes the JSON representation of the object.
        /// </summary>
        /// <param name="writer">The <see cref="T:Newtonsoft.Json.JsonWriter"/> to write to.</param><param name="value">The value.</param><param name="serializer">The calling serializer.</param>
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var str = (value as float?)?.ToString(CultureInfo.InvariantCulture) ??
                      ((double) value).ToString(CultureInfo.InvariantCulture);
            
            writer.WriteRawValue(str.Contains('.') ? str : str + '.');
        }

        /// <summary>
        /// Reads the JSON representation of the object.
        /// </summary>
        /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader"/> to read from.</param><param name="objectType">Type of the object.</param><param name="existingValue">The existing value of object being read.</param><param name="serializer">The calling serializer.</param>
        /// <returns>
        /// The object value.
        /// </returns>
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException("not intended for reading");
        }

        /// <summary>
        /// Determines whether this instance can convert the specified object type.
        /// </summary>
        /// <param name="objectType">Type of the object.</param>
        /// <returns>
        /// <c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
        /// </returns>
        public override bool CanConvert(Type objectType)
        {

            return typeof (float) == objectType || typeof (double) == objectType;
        }

        #endregion
    }
}