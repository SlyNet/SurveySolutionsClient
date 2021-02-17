using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class AssignmentAudioRecordingEnabled
    {
        /// <summary>
        /// Enabled for assignment. If null related questionnaire setting is used
        /// </summary>
        [DataMember(IsRequired = true)]
        public bool Enabled { get; set; }
    }
}
