#nullable enable
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class WorkspaceUpdateApiView
    {
        [DataMember(IsRequired = true)]
        public string? DisplayName { get; set; }
    }
}
