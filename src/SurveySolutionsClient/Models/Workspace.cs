using System;

namespace SurveySolutionsClient.Models
{
    public class Workspace
    {
        public string Name { get; set; }
        
        public string DisplayName { get; set; }
        
        public DateTime? DisabledAtUtc { get; set; }
    }
}
