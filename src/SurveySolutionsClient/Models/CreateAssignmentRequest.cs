using System.Collections.Generic;
using System.Text.Json.Serialization;
using SurveySolutionsClient.JsonConverters;

namespace SurveySolutionsClient.Models
{
    public class CreateAssignmentRequest
    {
        /// <summary>
        /// Username of the interviewer to be assigned for assignment.
        /// </summary>
        /// <value>
        /// The responsible.
        /// </value>
        public string Responsible { get; set; }

        /// <summary>
        /// Maximum number of allowed to create assignments.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// QuestionnaireId for assignment
        /// </summary>
        [JsonConverter(typeof(QuestionnaireIdentityConverter))]
        public QuestionnaireIdentity QuestionnaireId { get; set; }

        /// <summary>
        /// List of questions that should be pre-answered inside created interview.
        /// </summary>
        public List<AssignmentIdentifyingDataItem> IdentifyingData { get; set; } = new();

        /// <summary>
        /// Email to send assignment link to.
        /// </summary>
        /// <value>
        /// The email.
        /// </value>
        public string? Email { get; set; }

        /// <summary>
        /// Password protection for assignment.
        /// </summary>
        /// <value>
        /// The password.
        /// </value>
        public string? Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [web mode] is enabled.
        /// </summary>
        /// <value>
        ///   <c>true</c> if [web mode]; otherwise, <c>false</c>.
        /// </value>
        public bool WebMode { get; set; }

        /// <summary>
        /// Gets or sets the audio recording enabling.
        /// </summary>
        /// <value>
        /// The is audio recording enabled.
        /// </value>
        public bool? IsAudioRecordingEnabled { get; set; }

        /// <summary>
        /// Gets or sets the comments for assignment.
        /// </summary>
        /// <value>
        /// The comments.
        /// </value>
        public string? Comments { get; set; }

        /// <summary>
        /// List of protected variables
        /// </summary>
        /// <value>
        /// The protected variables.
        /// </value>
        public List<string> ProtectedVariables { get; set; } = new();
    }
}