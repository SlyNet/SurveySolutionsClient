using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Represents single verification error.
    /// </summary>
    public class AssignmentVerificationError
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentVerificationError"/> class.
        /// </summary>
        public AssignmentVerificationError()
        {
            this.References = new List<AssignmentCreationReference>();
        }

        /// <summary>
        /// Gets or sets the error code.
        /// </summary>
        /// <value>
        /// The code.
        /// </value>
        public string? Code { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the error references.
        /// </summary>
        /// <value>
        /// The references.
        /// </value>
        public List<AssignmentCreationReference> References { get; set; }


        /// <inheritdoc />
        public override string ToString() => $"{this.Code}: {this.Message}";
    }
}