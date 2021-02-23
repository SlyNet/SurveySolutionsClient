using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class WorkspaceCreateRequest
    {
        public WorkspaceCreateRequest(string name, string displayName)
        {
            Name = name;
            DisplayName = displayName;
        }

        public string Name { get; set; }
        
        public string DisplayName { get; set; }
    }
}
