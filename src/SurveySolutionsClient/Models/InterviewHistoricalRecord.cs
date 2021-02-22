using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using SurveySolutionsClient.JsonConverters;

namespace SurveySolutionsClient.Models
{
    public class InterviewHistoricalRecord
    {
        /// <summary>
        /// Gets or sets the index of record. Should be used for sorting.
        /// </summary>
        public long  Index { get; set; }

        /// <summary>
        /// Gets or sets the action.
        /// </summary>
        /// <value>
        /// The action.
        /// </value>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public InterviewHistoricalAction Action { get; set; }

        /// <summary>
        /// Gets or sets the name of the action originator.
        /// </summary>
        /// <value>
        /// The name of the originator.
        /// </value>
        public string OriginatorName { get; set; }

        /// <summary>
        /// Gets or sets the originator role.
        /// </summary>
        /// <value>
        /// The originator role.
        /// </value>
        public string OriginatorRole { get; set; }

        public Dictionary<string, string> Parameters { get; set; } = new();

        /// <summary>
        /// Gets or sets the timestamp.
        /// </summary>
        /// <value>
        /// The timestamp.
        /// </value>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the client timezone offset.
        /// </summary>
        /// <value>
        /// The offset.
        /// </value>
        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan? Offset { get; set; }
    }
}
