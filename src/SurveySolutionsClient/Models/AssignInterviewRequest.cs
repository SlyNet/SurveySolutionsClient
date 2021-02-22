using System;

namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Provide either responsible id or responsible name
    /// </summary>
    public class AssignInterviewRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignInterviewRequest"/> class.
        /// </summary>
        /// <param name="responsibleId">The responsible identifier.</param>
        /// <param name="responsibleName">Name of the responsible.</param>
        /// <exception cref="InvalidOperationException">Either responsible id or responsible name should be provided</exception>
        public AssignInterviewRequest(Guid? responsibleId, string? responsibleName)
        {
            if (responsibleId == null && responsibleName == null)
            {
                throw new InvalidOperationException("Either responsible id or responsible name should be provided");
            }

            ResponsibleId = responsibleId;
            ResponsibleName = responsibleName;
        }

        /// <summary>
        /// New responsible id
        /// </summary>
        
        public Guid? ResponsibleId { set; get; }
        /// <summary>
        /// New responsible login 
        /// </summary>
        public string? ResponsibleName { set; get; }
    }
}