using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ParkitectNexus.AssetMagic
{
    public class DataObjectParser
    {
        private readonly IEnumerable<Type> _knownTypes;

        public DataObjectParser()
        {
        }

        public DataObjectParser(IEnumerable<Type> knownTypes)
        {
            _knownTypes = knownTypes;
        }

        public DataObjectParser(params Type[] knownTypes)
        {
            _knownTypes = knownTypes;
        }

        public DataObject Parse(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input));

            var data = JsonConvert.DeserializeObject<IDictionary<string, object>>(input, new MyConverter());

            object typeNameObject;
            var type = typeof (DataObject);
            if (data.TryGetValue("@type", out typeNameObject))
            {
                var typeName = typeNameObject as string;
                if (typeName != null)
                {
                    var availableType = _knownTypes?.FirstOrDefault(t => t.Name == typeName) ??
                                        _knownTypes.FirstOrDefault(t =>
                                        {
                                            var attr = t.GetCustomAttribute<DataObjectNameAttribute>();
                                            return attr != null && Regex.IsMatch(typeName, attr.RegularExpression);
                                        });

                    if (availableType != null && typeof (DataObject).IsAssignableFrom(availableType))
                        type = availableType;
                }
            }

            var instance = Activator.CreateInstance(type) as DataObject;
            instance.AddRange(data);

            return instance;
        }
    }

    public class MyConverter : CustomCreationConverter<IDictionary<string, object>>
    {
        public override IDictionary<string, object> Create(Type objectType)
        {
            return new Dictionary<string, object>();
        }

        public override bool CanConvert(Type objectType)
        {
            // in addition to handling IDictionary<string, object>
            // we want to handle the deserialization of dict value
            // which is of type object
            return objectType == typeof(object) || base.CanConvert(objectType);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.StartObject
                || reader.TokenType == JsonToken.Null)
                return base.ReadJson(reader, objectType, existingValue, serializer);

            // if the next token is not an object
            // then fall back on standard deserializer (strings, numbers etc.)
            return serializer.Deserialize(reader);
        }
    }
}