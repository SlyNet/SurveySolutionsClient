using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class AssignmentsListView : BaseApiView
    {
        public List<AssignmentViewItem> Assignments { get; set; }
    }
}