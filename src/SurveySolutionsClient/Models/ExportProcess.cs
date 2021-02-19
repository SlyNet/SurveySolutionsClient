using System;
using System.Text.Json.Serialization;

namespace SurveySolutionsClient.Models
{
    public class ExportProcess : CreateExportProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExportProcess"/> class.
        /// </summary>
        public ExportProcess()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExportProcess"/> class.
        /// </summary>
        /// <param name="questionnaireId">The questionnaire identifier.</param>
        public ExportProcess(QuestionnaireIdentity questionnaireId) : base(questionnaireId)
        {
        }

        /// <summary>
        /// Export process id
        /// </summary>
        public long JobId { get; set; }

        /// <summary>
        /// Format of export data to download
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ExportStatus ExportStatus { get; set; }

        /// <summary>
        /// Export process stated date
        /// </summary>
        public DateTime? StartDate { get; set; }

        /// <summary>
        /// Export process completed date
        /// </summary>
        public DateTime? CompleteDate { get; set; }

        /// <summary>
        /// Progress of export in percents
        /// </summary>
        public int Progress { get; set; }

        /// <summary>
        /// Estimated time to finish of export
        /// </summary>
        public TimeSpan? ETA { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string? Error { get; set; }

        /// <summary>
        /// Links for cancelling export process and downloading data file
        /// </summary>
        public ExportJobLinks Links { get; set; } = new ExportJobLinks();

        /// <summary>
        /// True, if export process is finished and exported file ready for download, otherwise false 
        /// </summary>
        public bool HasExportFile { get; set; }
    }
}