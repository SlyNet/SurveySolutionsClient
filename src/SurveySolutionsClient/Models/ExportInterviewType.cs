namespace SurveySolutionsClient.Models
{
    public enum ExportInterviewType
    {
        All,
        SupervisorAssigned = 40,
        InterviewerAssigned = 60,
        Completed = 100,

        RejectedBySupervisor = 65,
        ApprovedBySupervisor = 120,

        RejectedByHeadquarters = 125,
        ApprovedByHeadquarters = 130
    }
}