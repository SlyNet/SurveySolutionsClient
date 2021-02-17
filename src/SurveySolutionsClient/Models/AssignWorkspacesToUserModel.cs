using System;

namespace SurveySolutionsClient.Models
{
    public class AssignWorkspacesToUserModel
    {
        public AssignWorkspacesToUserModel()
        {
            Workspaces = Array.Empty<string>();
        }

        
        public Guid[] UserIds { get; set; }

        
        public string[] Workspaces { get; set; }

        public AssignWorkspacesMode Mode { get; set; } = AssignWorkspacesMode.Assign;
    }
}
