using System.Text.Json.Serialization;
using SurveySolutionsClient.JsonConverters;

namespace SurveySolutionsClient.Models
{
    public record AssignmentIdentifyingDataItem
    {
        [JsonConverter(typeof(IdentityJsonConverter))]
        public Identity? Identity { get; set; }

        public string? Variable { get; set; }

        public string? Answer { get; set; }
    }
}