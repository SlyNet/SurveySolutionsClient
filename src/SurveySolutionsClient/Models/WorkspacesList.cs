#nullable enable
using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class WorkspacesList : BaseList
    {
        public WorkspacesList(int offset, int limit, int totalCount, IEnumerable<WorkspaceApiView> workspaces)
        {
            Offset = offset;
            Limit = limit;
            TotalCount = totalCount;
            Workspaces = workspaces;
        }

        public IEnumerable<WorkspaceApiView> Workspaces { get; set; }
    }
}
