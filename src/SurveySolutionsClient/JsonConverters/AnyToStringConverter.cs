using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SurveySolutionsClient.JsonConverters
{
    public class AnyToStringConverter : JsonConverter<object>
    {
        public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetDouble();
            }

            var read = reader.GetString();
            return read;
        }

        public override void Write(Utf8JsonWriter writer, object value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}