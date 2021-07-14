using System;

namespace SurveySolutionsClient.Models
{
    public class AssignWorkspaceInfo
    {
        public AssignWorkspaceInfo()
        {
        }

        public AssignWorkspaceInfo(string workspace, Guid? supervisorId = null)
        {
            Workspace = workspace;
            SupervisorId = supervisorId;
        }
        
        public string Workspace { get; set; }

        public Guid? SupervisorId { get; set; }
    }
}