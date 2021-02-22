using System.Collections.Generic;
using System.Linq;

namespace SurveySolutionsClient.Models
{
    public class QuestionnairesList : BaseList
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionnairesList"/> class.
        /// </summary>
        public QuestionnairesList()
        {
            this.Questionnaires = Enumerable.Empty<QuestionnaireItem>();
        }

        /// <summary>
        /// Gets or sets the questionnaires list.
        /// </summary>
        /// <value>
        /// The questionnaires.
        /// </value>
        public IEnumerable<QuestionnaireItem> Questionnaires { get; set; } 
    }
}
