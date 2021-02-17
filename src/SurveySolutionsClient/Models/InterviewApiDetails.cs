using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class InterviewApiDetails
    {
        [DataMember(IsRequired = true)]
        
        public List<QuestionApiItem> Answers { set; get; }
    }
}
