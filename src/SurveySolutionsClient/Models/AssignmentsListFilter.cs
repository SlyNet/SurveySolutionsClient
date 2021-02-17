using System;

namespace SurveySolutionsClient.Models
{
    public class AssignmentsListFilter
    {
        /// <summary>
        /// Filter result by custom search query
        /// </summary>
        public string? SearchBy { get; set; }

        /// <summary>
        /// Questionnaire Id in format of `{QuestionnaireId}${Version}`
        /// </summary>
        public QuestionnaireIdentity? QuestionnaireId { get; set; }

        /// <summary>
        /// Responsible user Id on name
        /// </summary>
        public string? Responsible { get; set; }

        /// <summary>
        /// Supervisor id
        /// </summary>
        public Guid? SupervisorId { get; set; }

        /// <summary>
        /// Search for only archived assignments. 
        /// </summary>
        public bool? ShowArchive { get; set; }

        /// <summary>
        /// Possible values are
        /// Id, ResponsibleName, InterviewsCount, Quantity, UpdatedAtUtc, CreatedAtUtc
        /// Followed by ordering direction "ASC" or "DESC"
        /// </summary>
        public string? Order { get; set; }

        /// <summary>
        /// Number of records to skip
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// Maximum row count to return
        /// </summary>
        public int? Limit { get; set; }
    }
}