using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
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
        Task<FullAssignment> DetailsAsync(int id, CancellationToken cancellationToken = default);

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
        Task<Assignment> ArchiveAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Un archives assignment.
        /// </summary>
        /// <param name="id">The assignment id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Updated assignment details</returns>
        Task<Assignment> UnArchiveAsync(int id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assigns responsible for specified assignment.
        /// </summary>
        /// <param name="id">The assignment id.</param>
        /// <param name="assigneeRequest">The assignee details.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Updated assignment details</returns>
        Task<Assignment> AssignAsync(int id, AssignmentResponsible assigneeRequest,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets quantity of interviews to be collected by assignment.
        /// </summary>
        /// <param name="id">The assignment id.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>Updated assignment details</returns>
        Task<Assignment> ChangeQuantityAsync(int id, int quantity, CancellationToken cancellationToken = default);


        /// <summary>
        /// Closes assignment by setting the quantity to the amount of collected interviews.
        /// </summary>
        /// <param name="id">The assignment id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Updated assignment details</returns>
        /// <remarks>Works properly only with survey solutions version newer than 20.03</remarks>
        Task<Assignment> CloseAsync(int id, CancellationToken cancellationToken = default);


        /// <summary>
        /// Creates new assignment.
        /// </summary>
        /// <param name="createItem">Assignment details.</param>
        /// <returns>Created assignment information</returns>
        Task<CreateAssignmentResult> CreateAsync(CreateAssignmentRequest createItem, CancellationToken cancellationToken = default);
    }
}