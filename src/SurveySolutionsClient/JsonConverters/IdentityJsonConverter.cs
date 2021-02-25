using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.JsonConverters
{
    internal class IdentityJsonConverter :  JsonConverter<Identity>
    {
        public override Identity? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var value = reader.GetString();
            if (value == null) return null;
            return Identity.Parse(value);
        }

        public override void Write(Utf8JsonWriter writer, Identity value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}