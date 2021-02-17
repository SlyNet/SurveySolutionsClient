using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class QuestionApiItem
    {
        public QuestionApiItem(string variableName, Identity questionId, string answer)
        {
            VariableName = variableName;
            QuestionId = questionId;
            Answer = answer;
        }

        [DataMember(IsRequired = true)]
        public string VariableName { set; get; }
        
        [DataMember(IsRequired = true)]
        public Identity QuestionId { get; set; }

        [DataMember(IsRequired = false)]
        public string Answer { set; get; }
    }
}