namespace SurveySolutionsClient.Models
{
    public class CreateAssignmentResult
    {
        public Assignment? Assignment { get; set; }

        public ImportDataVerificationState? VerificationStatus { get; set; }

        public string? WebInterviewLink { get; set; }
        
        public string? ValidationErrorMessage { get; set; }
    }
}