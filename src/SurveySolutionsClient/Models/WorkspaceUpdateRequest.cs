#nullable enable
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class WorkspaceUpdateRequest
    {
        public WorkspaceUpdateRequest(string displayName)
        {
            DisplayName = displayName;
        }

        public string DisplayName { get; set; }
    }
}
