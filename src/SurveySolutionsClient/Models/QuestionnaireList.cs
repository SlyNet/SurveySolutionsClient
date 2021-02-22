using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class QuestionnaireList : BaseList
    {
        
        public IEnumerable<QuestionnaireItem> Questionnaires { get; private set; }
    }
}
