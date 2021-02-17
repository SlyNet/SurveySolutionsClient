namespace SurveySolutionsClient.Models
{
    public class InterviewAnswer
    {
        public Identity Identity { get; set; }
        public AbstractAnswer Answer { get; set; }
        public string Variable { get; set; }
    }
}