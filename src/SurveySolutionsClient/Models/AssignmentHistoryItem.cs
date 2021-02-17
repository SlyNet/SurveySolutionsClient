using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Represents single action executed on assignment.
    /// </summary>
    public class AssignmentHistoryItem
    {
        public AssignmentHistoryItem()
        {
            AdditionalData = new Dictionary<string, string>();
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AssignmentHistoryAction Action { get; set; }

        public string ActorName { get; set; }

        public DateTime UtcDate { get; set; }

        /// <summary>
        /// Additional data related to action.
        /// </summary>
        public Dictionary<string, string> AdditionalData { get; set; }
    }
}