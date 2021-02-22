using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class Interview
    {
        public Interview()
        {
            this.Answers = new List<AnsweredQuestion>();
        }

        /// <summary>
        /// Gets or sets the answers.
        /// </summary>
        public List<AnsweredQuestion> Answers { set; get; }
    }
}
