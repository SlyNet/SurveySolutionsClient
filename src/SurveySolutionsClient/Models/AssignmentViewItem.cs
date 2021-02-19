using System;

namespace SurveySolutionsClient.Models
{
    public class AssignmentViewItem
    {
        public int Id { get; set; }

        public Guid ResponsibleId { get; set; }

        /// <summary>
        /// Name of the responsible person
        /// Can be used for ordering
        /// </summary>
        public string ResponsibleName { get; set; }

        /// <summary>
        /// Questionnaire Id 
        /// </summary>
        public string QuestionnaireId { get; set; }

        /// <summary>
        /// Quantity of submitted interviews for this assignment
        /// Can be used for ordering
        /// </summary>
        public int InterviewsCount { get; set; }

        /// <summary>
        /// Maximum allowed quantity of interviews that can be created from this assignment
        /// Can be used for ordering
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Archived status to filter by. True or False
        /// </summary>
        public bool Archived { get; set; }

        /// <summary>
        /// Date (UTC) when assignment were created
        /// Can be used for ordering
        /// </summary>
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        /// Last Update Date (UTC) of assignment
        /// Can be used for ordering
        /// </summary>
        public DateTime UpdatedAtUtc { get; set; }

        public string? Email { get; set; }

        public string? Password { get; set; }

        public bool? WebMode { get; set; }

        /// <summary>
        /// Represents date (UTC) when assignment was received by tablet
        /// </summary>
        public DateTime? ReceivedByTabletAtUtc { get; set; }

        /// <summary>
        /// Determines if interview from this assignment must record voice during interview (only on tablet)
        /// </summary>
        public bool IsAudioRecordingEnabled { get; set; }
    }
}