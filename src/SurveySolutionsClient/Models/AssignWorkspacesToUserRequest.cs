using System;

namespace SurveySolutionsClient.Models
{
    public class AssignWorkspacesToUserRequest
    {
        public AssignWorkspacesToUserRequest()
        {
            Workspaces = Array.Empty<AssignWorkspaceInfo>();
        }

        public Guid[] UserIds { get; set; }

        public AssignWorkspaceInfo[] Workspaces { get; set; }

        public AssignWorkspacesMode Mode { get; set; } = AssignWorkspacesMode.Assign;
    }
}
