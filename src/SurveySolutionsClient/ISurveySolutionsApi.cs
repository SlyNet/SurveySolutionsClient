﻿namespace SurveySolutionsClient
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

        /// <summary>
        /// Gets the entry point to questionnaires related methods.
        /// </summary>
        /// <value>
        /// The questionnaires.
        /// </value>
        IQuestionnaires Questionnaires { get; }

        /// <summary>
        /// Gets the settings api.
        /// </summary>
        /// <value>
        /// The settings.
        /// </value>
        ISettings Settings { get; }

        /// <summary>
        /// Gets the users api.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        IUsers Users { get; }

        /// <summary>
        /// Gets the work spaces api.
        /// </summary>
        /// <value>
        /// The work spaces api.
        /// </value>
        IWorkSpaces WorkSpaces {get;}

        /// <summary>
        /// Gets the ability to execute GraphQL api calls.
        /// </summary>
        /// <value>
        /// The graph ql.
        /// </value>
        IGraphQl GraphQl { get; }
    }
}