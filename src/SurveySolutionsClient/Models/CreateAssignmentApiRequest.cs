using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class CreateAssignmentApiRequest
    {
        
        public string Responsible { get; set; }

        /// <summary>
        /// Maximum number of allowed to create assignments
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// QuestionnaireId for assignment
        /// </summary>
        public string QuestionnaireId { get; set; }

        public List<AssignmentIdentifyingDataItem> IdentifyingData { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool WebMode { get; set; }

        public bool? IsAudioRecordingEnabled { get; set; }
        public string Comments { get; set; }

        /// <summary>
        /// List of protected variables
        /// </summary> 
        public List<string> ProtectedVariables { get; set; }
    }
}