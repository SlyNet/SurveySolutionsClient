namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Container for request argument for list of generated exports
    /// </summary>
    public class ExportListRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportListRequest"/> class.
        /// </summary>
        /// <param name="questionnaireIdentity">The questionnaire identity.</param>
        public ExportListRequest(QuestionnaireIdentity questionnaireIdentity)
        {
            QuestionnaireIdentity = questionnaireIdentity;
        }

        public ExportType ExportType { get; set; } = Models.ExportType.Tabular;

        public ExportInterviewType InterviewStatus { get; set; } = ExportInterviewType.All;

        public QuestionnaireIdentity QuestionnaireIdentity { get; set; }

        public ExportStatus? ExportStatus { get; set; }

        public bool? HasFile { get; set; }

        public int? limit { get; set; }

        public int? offset { get; set; }
    }
}