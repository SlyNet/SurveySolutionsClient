namespace SurveySolutionsClient.Models
{
    public class InterviewImportReference
    {
        public PreloadedDataVerificationReferenceType Type { get; private set; }
        public string Column { get; private set; }
        public long? Row { get; private set; }
        public string Content { get; private set; }
        public string DataFile { get; private set; }
    }
}