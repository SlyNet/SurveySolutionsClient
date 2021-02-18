using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Verification details on assignment creation.
    /// </summary>
    public class ImportDataVerificationState
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImportDataVerificationState"/> class.
        /// </summary>
        public ImportDataVerificationState()
        {
            this.Errors = new List<AssignmentVerificationError>();
        }

        /// <summary>
        /// Gets or sets the errors.
        /// </summary>
        /// <value>
        /// The errors.
        /// </value>
        public List<AssignmentVerificationError> Errors { set; get; }
    }
}