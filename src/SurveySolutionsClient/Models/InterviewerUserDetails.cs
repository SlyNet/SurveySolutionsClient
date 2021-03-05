using System;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class InterviewerUserDetails : UserDetails
    {
        
        public string SupervisorName { get; set; }

        
        public Guid SupervisorId { get; set; }

        
        public bool IsLockedBySupervisor { get; set; }

        
        public bool IsLockedByHeadquarters { get; set;}
    }
}