using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class AssignmentDetails : AssignmentViewItem
    {
        [DataMember] public List<AssignmentIdentifyingDataItem> IdentifyingData { get; set; }
    }
}