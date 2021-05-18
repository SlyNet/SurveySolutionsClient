using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.JsonConverters
{
     public class RosterVectorConverter : JsonConverter<RosterVector>
    {
        public override RosterVector? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            List<int> vector = new();

            while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
            {
                if (reader.TokenType != JsonTokenType.Comment)
                {
                    vector.Add((int) reader.GetDouble());
                }
            }

            return new RosterVector(vector.ToArray());
        }

        public override void Write(Utf8JsonWriter writer, RosterVector value, JsonSerializerOptions options)
        {
            writer.WriteStartArray();
            foreach (var coordinate in value)
            {
                writer.WriteNumberValue(coordinate);
            }
            writer.WriteEndArray();
        }
    }
}