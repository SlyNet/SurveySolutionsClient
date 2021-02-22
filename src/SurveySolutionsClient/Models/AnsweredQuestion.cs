namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Represents single answered question in the interview
    /// </summary>
    public record AnsweredQuestion
    {
        /// <summary>
        /// Gets or sets the name of the variable.
        /// </summary>
        /// <value>
        /// The name of the variable.
        /// </value>
        public string VariableName { set; get; }

        /// <summary>
        /// Gets or sets the question identifier.
        /// </summary>
        /// <value>
        /// The question identifier.
        /// </value>
        public Identity QuestionId { get; set; }

        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        /// <value>
        /// The answer.
        /// </value>
        public string Answer { set; get; }
    }
}