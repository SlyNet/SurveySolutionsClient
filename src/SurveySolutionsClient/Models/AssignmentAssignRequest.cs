using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class AssignmentAssignRequest
    {
        [DataMember]
        public string Responsible { get; set; }
    }
}