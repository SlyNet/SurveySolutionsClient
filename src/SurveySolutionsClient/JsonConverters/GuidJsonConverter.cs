using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SurveySolutionsClient.JsonConverters
{
    internal class GuidJsonConverter :  JsonConverter<Guid>
    {
        public override Guid Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            Guid.TryParse(reader.GetString(), out Guid result);
            return result;
        }

        public override void Write(Utf8JsonWriter writer, Guid value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString("N"));
        }
    }
}