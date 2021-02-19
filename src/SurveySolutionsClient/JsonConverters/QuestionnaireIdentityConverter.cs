using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.JsonConverters
{
    internal class QuestionnaireIdentityConverter  : JsonConverter<QuestionnaireIdentity>
    {
        public override QuestionnaireIdentity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return QuestionnaireIdentity.Parse(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, QuestionnaireIdentity value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString());
        }
    }
}