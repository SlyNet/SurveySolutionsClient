using System;

namespace SurveySolutionsClient.Models
{
    public class WorkspaceApiView
    {
        public string Name { get; set; }
        
        public string DisplayName { get; set; }
        
        public DateTime? DisabledAtUtc { get; set; }
    }
}
