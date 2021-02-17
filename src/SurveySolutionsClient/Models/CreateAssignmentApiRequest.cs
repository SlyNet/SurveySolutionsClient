using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class CreateAssignmentApiRequest
    {
        [DataMember]
        
        public string Responsible { get; set; }

        /// <summary>
        /// Maximum number of allowed to create assignments
        /// </summary>
        [DataMember]
        public int? Quantity { get; set; }

        /// <summary>
        /// QuestionnaireId for assignment
        /// </summary>
        [DataMember]
        
        public string QuestionnaireId { get; set; }

        [DataMember]
        
        public List<AssignmentIdentifyingDataItem> IdentifyingData { get; set; } =
            new List<AssignmentIdentifyingDataItem>();


        [DataMember] public string Email { get; set; }

        [DataMember] public string Password { get; set; }

        [DataMember] public bool WebMode { get; set; }

        [DataMember] public bool? IsAudioRecordingEnabled { get; set; }
        [DataMember] public string Comments { get; set; }

        /// <summary>
        /// List of protected variables
        /// </summary> 
        [DataMember]
        public List<string> ProtectedVariables { get; set; } = new List<string>();
    }
}