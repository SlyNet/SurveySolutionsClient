#nullable enable
using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class WorkspacesList : BaseList
    {
        public WorkspacesList(int offset, int limit, int totalCount, IEnumerable<Workspace> workspaces)
        {
            Offset = offset;
            Limit = limit;
            TotalCount = totalCount;
            Workspaces = workspaces;
        }

        public IEnumerable<Workspace> Workspaces { get; set; }
    }
}
