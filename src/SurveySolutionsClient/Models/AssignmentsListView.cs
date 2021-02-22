using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class AssignmentsListView : BaseList
    {
        public List<AssignmentViewItem> Assignments { get; set; }
    }
}