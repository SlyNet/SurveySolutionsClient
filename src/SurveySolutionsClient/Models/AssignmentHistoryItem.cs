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
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentHistoryItem"/> class.
        /// </summary>
        public AssignmentHistoryItem()
        {
            AdditionalData = new Dictionary<string, string>();
            ActorName = "";
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public AssignmentHistoryAction Action { get; set; }

        /// <summary>
        /// Gets the name of the actor.
        /// </summary>
        /// <value>
        /// The name of the actor.
        /// </value>
        public string ActorName { get; set; }

        /// <summary>
        /// Gets the utc date when action occurred.
        /// </summary>
        /// <value>
        /// The UTC date.
        /// </value>
        public DateTime UtcDate { get; set; }

        /// <summary>
        /// Additional data related to action.
        /// </summary>
        public Dictionary<string, string> AdditionalData { get; set; }
    }
}