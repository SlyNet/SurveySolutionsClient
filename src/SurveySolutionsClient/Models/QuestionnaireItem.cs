using System;
using System.Text.Json.Serialization;
using SurveySolutionsClient.JsonConverters;

namespace SurveySolutionsClient.Models
{
    public class QuestionnaireItem
    {
        [JsonConverter(typeof(QuestionnaireIdentityConverter))]
        public QuestionnaireIdentity QuestionnaireIdentity { get; set; }

        public Guid QuestionnaireId { get; set; }

        public long Version { get; set; }

        public string Title { get; set; }

        public string Variable { get; set; }

        public DateTime LastEntryDate { get; set; }

        public bool IsAudioRecordingEnabled { get; set; }

        public bool WebModeEnabled { get; set; }
    }
}
