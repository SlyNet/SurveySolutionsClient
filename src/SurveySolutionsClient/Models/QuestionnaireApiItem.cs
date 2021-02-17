using System;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class QuestionnaireApiItem
    {
        [DataMember]
        public string QuestionnaireIdentity { get; set; }

        [DataMember]
        
        public Guid QuestionnaireId { get; set; }

        [DataMember]
        
        public long Version { get; set; }

        [DataMember]
        
        public string Title { get; set; }

        [DataMember]
        
        public string Variable { get; set; }

        [DataMember]
        
        public DateTime LastEntryDate { get; set; }

        [DataMember]
        public bool IsAudioRecordingEnabled { get; set; }

        [DataMember]
        public bool WebModeEnabled { get; set; }
    }
}
