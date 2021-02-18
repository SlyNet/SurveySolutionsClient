namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Request object to change audio recording settings
    /// </summary>
    public class AssignmentAudioRecordingEnabled
    {
        /// <summary>
        /// Enabled for assignment. If null related questionnaire setting is used
        /// </summary>
        public bool Enabled { get; set; }
    }
}
