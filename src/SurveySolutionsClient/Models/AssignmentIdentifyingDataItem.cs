using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SurveySolutionsClient.Models
{
    public record AssignmentIdentifyingDataItem
    {
        [JsonConverter(typeof(IdentityJsonConverter))]
        public Identity Identity { get; set; }

        public string Variable { get; set; }

        public string Answer { get; set; }
    }

    public class IdentityJsonConverter :  JsonConverter<Identity>
    {
        public override Identity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Identity.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, Identity value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}