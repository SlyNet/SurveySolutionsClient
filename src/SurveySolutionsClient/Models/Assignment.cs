using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class Assignment : AssignmentViewItem
    {
        public Assignment()
        {
            IdentifyingData = new List<AssignmentIdentifyingDataItem>();
        }

        public List<AssignmentIdentifyingDataItem> IdentifyingData { get; set; }
    }
}