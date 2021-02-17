using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class FullAssignmentDetails : AssignmentDetails
    {
        [DataMember]
        public List<InterviewAnswer> Answers { get; set; }
    }
}