using System;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SurveySolutionsClient.JsonConverters
{
    public class TimeSpanConverter : JsonConverter<TimeSpan>
    {
        public override TimeSpan Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            var stringValue = reader.GetString();
            return TimeSpan.Parse(stringValue, CultureInfo.InvariantCulture);
        }

        public override void Write(Utf8JsonWriter writer, TimeSpan value, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }
    }
}