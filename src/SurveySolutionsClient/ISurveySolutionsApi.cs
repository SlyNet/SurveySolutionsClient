namespace SurveySolutionsClient
{
    /// <summary>
    /// Entry point to all api of Survey Solutions
    /// </summary>
    public interface ISurveySolutionsApi
    {
        /// <summary>
        /// Gets assignments related api actions
        /// </summary>
        IAssignments Assignments { get; }

        /// <summary>
        /// Gets the entry point to export related methods.
        /// </summary>
        IExport Export { get; }


        /// <summary>
        /// Gets the entry point to interview related methods.
        /// </summary>
        IInterviews Interviews { get; }
    }
}