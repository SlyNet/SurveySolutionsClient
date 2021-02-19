using System;
using System.Text.Json.Serialization;
using SurveySolutionsClient.JsonConverters;

namespace SurveySolutionsClient.Models
{
    public class CreateExportProcess
    {
        protected CreateExportProcess()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateExportProcess"/> class.
        /// </summary>
        /// <param name="questionnaireId">The questionnaire identifier.</param>
        public CreateExportProcess(QuestionnaireIdentity questionnaireId)
        {
            QuestionnaireId = questionnaireId;
        }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ExportType ExportType { get; set; } = ExportType.Tabular;
        
        [JsonConverter(typeof(QuestionnaireIdentityConverter))]
        public QuestionnaireIdentity QuestionnaireId { get; set; }

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ExportInterviewType InterviewStatus { get; set; } = ExportInterviewType.All;
      
        public DateTime? From { get; set; }
        
        /// <summary>
        /// Finished date for timeframe of exported interviews (when change was done to an interview). Should be in UTC date
        /// </summary>
        public DateTime? To { get; set; }
        
        /// <summary>
        /// Access token to external storage
        /// </summary>
        public string? AccessToken { get; set; }
        
        /// <summary>
        /// Refresh token to external storage
        /// </summary>
        public string? RefreshToken { get; set; }
        
        /// <summary>
        /// External storage type
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ExternalStorageType? StorageType { get; set; }

        /// <summary>
        /// Translation Id of the questionnaire
        /// </summary>
        public Guid? TranslationId { get; set; }

        public bool? IncludeMeta { get; set; }
    }
}