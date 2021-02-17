using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class UpdateRecordingRequest
    {
        [DataMember(IsRequired = true)]
        public bool Enabled { get; set; }
    }
}