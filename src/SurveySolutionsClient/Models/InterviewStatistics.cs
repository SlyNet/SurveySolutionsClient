using System;
using System.Text.Json.Serialization;
using SurveySolutionsClient.JsonConverters;

namespace SurveySolutionsClient.Models
{
    public class InterviewStatistics
    {
        /// <summary>
        /// Gets number of answered questions.
        /// </summary>
        /// <value>
        /// The answered.
        /// </value>
        public int Answered { get; set; }
        /// <summary>
        /// Gets number of unanswered questions.
        /// </summary>
        /// <value>
        /// The not answered.
        /// </value>
        public int NotAnswered { get; set; }
        /// <summary>
        /// Gets number of questions with flag.
        /// </summary>
        /// <value>
        /// The flagged.
        /// </value>
        public int Flagged { get; set; }
        
        public int NotFlagged { get; set; }

        public int Valid { get; set; }
        /// <summary>
        /// Gets number of questions with failed validations.
        /// </summary>
        /// <value>
        /// The invalid.
        /// </value>
        public int Invalid { get; set; }

        /// <summary>
        /// Gets number of questions the with comments.
        /// </summary>
        /// <value>
        /// The with comments.
        /// </value>
        public int WithComments { get; set; }
        /// <summary>
        /// Gets number of questions for interviewer.
        /// </summary>
        /// <value>
        /// For interviewer.
        /// </value>
        public int ForInterviewer { get; set; }
        /// <summary>
        /// Gets number of questions for supervisor.
        /// </summary>
        /// <value>
        /// For supervisor.
        /// </value>
        public int ForSupervisor { get; set; }

        public Guid InterviewId { get; set; }

        public string InterviewKey { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public InterviewStatus Status { get; set; }

        public Guid ResponsibleId { get; set; }

        public string ResponsibleName { get; set; }

        public int NumberOfInterviewers { get; set; }
        public int NumberRejectionsBySupervisor { get; set; }
        public int NumberRejectionsByHq { get; set; }

        [JsonConverter(typeof(TimeSpanConverter))]
        public TimeSpan? InterviewDuration { get; set; }
        public int AssignmentId { get; set; }
        public DateTime UpdatedAtUtc { get; set; }
    }
}
