using System.Text.Json.Serialization;
using SurveySolutionsClient.JsonConverters;

namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Represents single answer
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// Either <see langword="string"/> or a <see langword="double"/> value for the answer
        /// </summary>
        [JsonConverter(typeof(AnyToStringConverter))]
        public object Value { get; set; }
    }
}