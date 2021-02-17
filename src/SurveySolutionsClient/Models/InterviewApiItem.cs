using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class InterviewApiItem
    {
        [DataMember]
        public IEnumerable<InterviewFeaturedQuestion> FeaturedQuestions { get; set; }

        [DataMember]
        
        public Guid InterviewId { get; set; }

        [DataMember]
        
        public Guid QuestionnaireId { get; set; }

        [DataMember]
        
        public long QuestionnaireVersion { set; get; }

        [DataMember]
        public int? AssignmentId { get; }

        [DataMember]
        
        public Guid ResponsibleId { get; set; }

        [DataMember]
        
        public string ResponsibleName { get; set; }

        [DataMember]
        
        public int ErrorsCount { get; set; }

        [DataMember]
        
        public InterviewStatus Status { get; set; }
                
        [DataMember]
        
        public DateTime LastEntryDate { get; set; }

        [DataMember] 
        public bool ReceivedByDevice => ReceivedByDeviceAtUtc.HasValue;

        [DataMember]
        public DateTime? ReceivedByDeviceAtUtc { get; set; }
    }
}
