using System;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class WorkspaceApiView
    {
        [DataMember(IsRequired = true)]
        public string Name { get; set; }
        
        [DataMember(IsRequired = true)]
        public string DisplayName { get; set; }
        
        [DataMember]
        public DateTime? DisabledAtUtc { get; set; }
    }
}
