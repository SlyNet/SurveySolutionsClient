using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class FullAssignment : Assignment
    {
        public List<InterviewAnswer> Answers { get; set; }
    }
}