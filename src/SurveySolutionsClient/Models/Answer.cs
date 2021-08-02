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
        /// Either <see langword="string"/>, <see langword="double"/>, <see langword="DateTime"/>, or GeoPosition value for the answer
        /// </summary>
        [JsonConverter(typeof(AnswerConverter))]
        public object? Value { get; set; }

        /// <summary>
        /// Multiple choice question answer
        /// </summary>
        public int[]? CheckedValues { get; set; }

        /// <summary>
        /// Yes no answers
        /// </summary>
        public YesNoAnswer[]? CheckedOptions { get; set; }

        /// <summary>
        /// Barcode question answer
        /// </summary>
        public string? DecodedText { get; set; }

        /// <summary>
        /// Text list question answers
        /// </summary>
        public TextListAnswerRow[]? Rows { get; set; }
    }
}