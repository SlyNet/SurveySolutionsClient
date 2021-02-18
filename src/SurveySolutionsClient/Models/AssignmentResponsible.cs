namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// Request object to reassign assignment
    /// </summary>
    public class AssignmentResponsible
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AssignmentResponsible"/> class.
        /// </summary>
        /// <param name="responsible">The responsible login or user id.</param>
        public AssignmentResponsible(string responsible)
        {
            Responsible = responsible;
        }

        /// <summary>
        /// Gets the responsible login or user id.
        /// </summary>
        public string Responsible { get; }
    }
}