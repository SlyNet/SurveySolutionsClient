using System;
using System.Threading;
using System.Threading.Tasks;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient
{
    /// <summary>
    /// Questionnaire related methods
    /// </summary>
    public interface IQuestionnaires
    {
        /// <summary>
        /// Gets list of questionnaires imported on Headquarters.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        Task<QuestionnairesList> ListAsync(int page = 1, int pageSize = 10, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets the value indicating if audio recording enabled.
        /// </summary>
        /// <param name="questionnaireIdentity">The questionnaire identity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task<AudioRecordingEnabled> GetAudioRecordingEnabled(QuestionnaireIdentity questionnaireIdentity,
            CancellationToken cancellationToken = default);

        /// <summary>
        /// Sets the audio recording enabled for questionnaire.
        /// </summary>
        /// <param name="questionnaireIdentity">The questionnaire identity.</param>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns></returns>
        Task SetAudioRecordingEnabledAsync(QuestionnaireIdentity questionnaireIdentity,
            RecordAudioRequest request,
            CancellationToken cancellationToken = default);
    }
}