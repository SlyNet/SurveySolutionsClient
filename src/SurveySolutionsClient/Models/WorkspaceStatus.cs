namespace SurveySolutionsClient.Models
{
    public class WorkspaceStatus
    {
        public bool CanBeDeleted { get; set; }
        public string WorkspaceName { get; set; }
        public string WorkspaceDisplayName { get; set; }
        public long ExistingQuestionnairesCount { get; set; }
        public long InterviewersCount { get; set; }
        public long SupervisorsCount { get; set; }
        public int MapsCount { get; set; }
    }
}