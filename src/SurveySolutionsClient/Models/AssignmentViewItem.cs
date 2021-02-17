using System;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class AssignmentViewItem
    {
        [DataMember] public int Id { get; set; }

        [DataMember] public Guid ResponsibleId { get; set; }

        /// <summary>
        /// Name of the responsible person
        /// Can be used for ordering
        /// </summary>
        [DataMember]
        public string ResponsibleName { get; set; }

        /// <summary>
        /// Questionnaire Id 
        /// </summary>
        [DataMember]
        public string QuestionnaireId { get; set; }

        /// <summary>
        /// Quantity of submitted interviews for this assignment
        /// Can be used for ordering
        /// </summary>
        [DataMember]
        public int InterviewsCount { get; set; }

        /// <summary>
        /// Maximum allowed quantity of interviews that can be created from this assignment
        /// Can be used for ordering
        /// </summary>
        [DataMember]
        public int? Quantity { get; set; }

        /// <summary>
        /// Archived status to filter by. True or False
        /// </summary>
        [DataMember]
        public bool Archived { get; set; }

        /// <summary>
        /// Date (UTC) when assignment were created
        /// Can be used for ordering
        /// </summary>
        [DataMember]
        public DateTime CreatedAtUtc { get; set; }

        /// <summary>
        /// Last Update Date (UTC) of assignment
        /// Can be used for ordering
        /// </summary>
        [DataMember]
        public DateTime UpdatedAtUtc { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public bool? WebMode { get; set; }

        /// <summary>
        /// Represents date (UTC) when assignment was received by tablet
        /// </summary>
        [DataMember]
        public DateTime? ReceivedByTabletAtUtc { get; set; }

        /// <summary>
        /// Determines if interview from this assignment must record voice during interview (only on tablet)
        /// </summary>
        [DataMember]
        public bool IsAudioRecordingEnabled { get; set; }
    }
}