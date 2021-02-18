namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Single property error information.
    /// </summary>
    public class AssignmentCreationReference
    {
        /// <summary>
        /// Content provided in request that failed to be validated.
        /// </summary>
        /// <value>
        /// The content.
        /// </value>
        public string? Content { get; set; }

        /// <summary>
        /// Gets or sets the name of a property with failed validation.
        /// </summary>
        /// <value>
        /// The column.
        /// </value>
        public string? Column { get; set; }
    }
}