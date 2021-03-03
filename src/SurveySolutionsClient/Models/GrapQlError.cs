namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Detailed information regarding call error
    /// </summary>
    public class GrapQlError
    {
        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public string? Message { get; set; }

        /// <summary>
        /// Gets or sets the additional information regarding error.
        /// </summary>
        /// <value>
        /// The extensions.
        /// </value>
        public ErrorExtensions? Extensions {get; set; }
    }
}