using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class AssignmentDetails : AssignmentViewItem
    {
        public AssignmentDetails()
        {
            IdentifyingData = new List<AssignmentIdentifyingDataItem>();
        }

        public List<AssignmentIdentifyingDataItem> IdentifyingData { get; set; }
    }
}