using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class WorkspaceCreateApiView
    {
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        
        [DataMember(IsRequired = true)]
        public string DisplayName { get; set; }
    }
}
