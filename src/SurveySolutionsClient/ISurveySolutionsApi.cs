﻿using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

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
    }

    /// <summary>
    /// Assignments related actions
    /// </summary>
    public interface IAssignments
    {
        /// <summary>
        /// Gets single assignment details
        /// </summary>
        /// <param name="id">Assignment id</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<FullAssignmentDetails> DetailsAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets list of assignments that meet provided filtering details.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<AssignmentsListView> ListAsync(AssignmentsListFilter filter, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets history of changes for specified assignment.
        /// </summary>
        /// <param name="id">Assignment id.</param>
        /// <param name="start">Amount of events to skip.</param>
        /// <param name="length">Limit to number of returned events.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<AssignmentHistory> HistoryAsync(int id, int start = 0, int length = 30, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the value indicating if audio recording audit is going to be recorded during interview.
        /// </summary>
        /// <param name="id">The assignment id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<AssignmentAudioRecordingEnabled> GetAudioRecordingAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Enables/Disables audio recording for assignment.
        /// </summary>
        /// <param name="id">The assignment id.</param>
        /// <param name="request">The request body.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task SetAudioRecordingAsync(int id, UpdateRecordingRequest request, CancellationToken cancellationToken = default);


        /// <summary>
        /// Archives assignment.
        /// </summary>
        /// <param name="id">The assignment id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Updated assignment details</returns>
        Task<AssignmentDetails> ArchiveAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Un archives assignment.
        /// </summary>
        /// <param name="id">The assignment id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Updated assignment details</returns>
        Task<AssignmentDetails> UnArchiveAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assigns responsible for specified assignment.
        /// </summary>
        /// <param name="id">The assignment id.</param>
        /// <param name="assigneeRequest">The assignee details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Updated assignment details</returns>
        Task<AssignmentDetails> AssignAsync(int id, AssignmentAssignRequest assigneeRequest,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets quantity of interviews to be collected by assignment.
        /// </summary>
        /// <param name="id">The assignment id.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>Updated assignment details</returns>
        Task<AssignmentDetails> ChangeQuantityAsync(int id, int quantity, CancellationToken cancellationToken = default);


        /// <summary>
        /// Closes assignment by setting the quantity to the amount of collected interviews.
        /// </summary>
        /// <param name="id">The assignment id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Updated assignment details</returns>
        /// <remarks>Works properly only with survey solutions version newer than 20.03</remarks>
        Task<AssignmentDetails> CloseAsync(int id, CancellationToken cancellationToken = default);
    }
}