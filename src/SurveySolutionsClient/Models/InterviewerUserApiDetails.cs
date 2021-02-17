using System;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class InterviewerUserApiDetails : UserApiDetails
    {
        [DataMember]
        
        public string SupervisorName { get; }

        [DataMember]
        
        public Guid SupervisorId { get; }

        [DataMember]
        
        public bool IsLockedBySupervisor { get; }

        [DataMember]
        
        public bool IsLockedByHeadquarters { get; }
    }
}