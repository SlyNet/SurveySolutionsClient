using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.JsonConverters
{
    internal class AnswerConverter : JsonConverter<object>
    {
        public override object? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetDouble();
            }

            if (reader.TokenType == JsonTokenType.String)
            {
                if (reader.TryGetDateTime(out DateTime dateTimeAnswer))
                {
                    return dateTimeAnswer;
                }
            }

            if (reader.TokenType == JsonTokenType.StartObject)
            {
                using var token = JsonDocument.ParseValue(ref reader);

                if(token.RootElement.TryGetProperty(nameof(GeoPosition.Latitude), out JsonElement latitude))
                {
                    GeoPosition answer = new() {Latitude = latitude.GetDouble()};

                    if (token.RootElement.TryGetProperty(nameof(GeoPosition.Longitude), out JsonElement longitude))
                    {
                        answer.Longitude = longitude.GetDouble();
                    }

                    if (token.RootElement.TryGetProperty(nameof(GeoPosition.Altitude), out JsonElement altitude))
                    {
                        answer.Altitude = altitude.GetDouble();
                    }
                    
                    if (token.RootElement.TryGetProperty(nameof(GeoPosition.Accuracy), out JsonElement accuracy))
                    {
                        answer.Accuracy = accuracy.GetDouble();
                    }
                    
                    if (token.RootElement.TryGetProperty(nameof(GeoPosition.Timestamp), out JsonElement timeStamp))
                    {
                        answer.Timestamp = timeStamp.GetDateTimeOffset();
                    }
                    
                    return answer;
                }
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