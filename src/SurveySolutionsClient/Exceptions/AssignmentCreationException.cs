using System;
using SurveySolutionsClient.Models;

namespace SurveySolutionsClient.Exceptions
{
    /// <summary>
    /// Thrown when assignment was not created due to validation errors.
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class AssignmentCreationException : Exception
    {
        /// <summary>
        /// Error details.
        /// </summary>
        /// <value>
        /// The creation result.
        /// </value>
        public CreateAssignmentResult? CreationResult { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentCreationException"/> class.
        /// </summary>
        /// <param name="message">The text message.</param>
        /// <param name="creationResult">The creation result details.</param>
        public AssignmentCreationException(string message, CreateAssignmentResult? creationResult) : base(message)
        {
            CreationResult = creationResult;
        }
    }
}