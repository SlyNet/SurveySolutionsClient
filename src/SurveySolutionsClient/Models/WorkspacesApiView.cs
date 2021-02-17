#nullable enable
using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class WorkspacesApiView : BaseApiView
    {
        public WorkspacesApiView(int offset, int limit, int totalCount, IEnumerable<WorkspaceApiView> workspaces)
        {
            Offset = offset;
            Limit = limit;
            TotalCount = totalCount;
            Workspaces = workspaces;
        }

        public IEnumerable<WorkspaceApiView> Workspaces { get; set; }
    }
}
