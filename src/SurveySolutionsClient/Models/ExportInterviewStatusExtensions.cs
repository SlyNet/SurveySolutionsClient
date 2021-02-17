namespace SurveySolutionsClient.Models
{
    public static class ExportInterviewStatusExtensions
    {
        public static InterviewStatus? ToInterviewStatus(this ExportInterviewStatus? status)
        {
            return status != null ? (InterviewStatus?) status : null;
        }
    }
}
