using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
    /// <summary>
    /// Interview related actions
    /// </summary>
    public interface IInterviews
    {
        /// <summary>
        /// Gets interview details.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<Interview> DetailsAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes the interview.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task DeleteAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets interview history.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <remarks>Lists all events that will be exported in interview paradata.</remarks>
        Task<InterviewHistory> HistoryAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets PDF document for the specified interview.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<Stream> GetPdfAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets Statistics for the specified interview.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<InterviewStatistics> StatisticsAsync(Guid id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Approves the interview.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task ApproveAsync(Guid id, string? comment = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Assigns the new responsible interviewer.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="assignRequest">Request data.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task AssignAsync(Guid id, AssignInterviewRequest assignRequest, CancellationToken cancellationToken = default);

        /// <summary>
        ///Assigns supervisor
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="assignRequest">The assign request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task AssignSupervisorAsync(Guid id, AssignInterviewRequest assignRequest, CancellationToken cancellationToken = default);

        /// <summary>
        /// Approve interview as headquarters.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="comment">The comment.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task HqApproveAsync(Guid id, string? comment = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Reject interview as headquarters.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="comment">The comment.</param>
        /// <param name="responsibeId">The responsibe identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task HqRejectAsync(Guid id, string? comment = null, Guid? responsibeId = null,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Return interview from approved by headquarters status.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="comment">The comment.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task HqUnapproveAsync(Guid id, string? comment = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Rejects the interview.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="newResponsibleId">The new responsible identifier to assign rejected interview to. Can be <c>null</c> that will keep interview on same responsible.</param>
        /// <param name="comment">The comment.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task RejectAsync(Guid id, Guid? newResponsibleId = null, string? comment = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds comment to interview question.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="questionId">The question identifier.</param>
        /// <param name="commentText">The comment text.</param>
        /// <param name="rosterVector">Roster vector of question inside roster</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task CommentAsync(Guid id, Guid questionId, string commentText, RosterVector? rosterVector = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Adds comment to interview question.
        /// </summary>
        /// <param name="id">Interview id.</param>
        /// <param name="variableName">The question variable name.</param>
        /// <param name="commentText">The comment text.</param>
        /// <param name="rosterVector">Roster vector of question inside roster</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task CommentAsync(Guid id, string variableName, string commentText, RosterVector? rosterVector = null, CancellationToken cancellationToken = default);
    }
}