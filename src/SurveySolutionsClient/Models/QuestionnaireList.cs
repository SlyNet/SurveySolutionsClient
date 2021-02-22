using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class QuestionnaireList : BaseList
    {
        
        public IEnumerable<QuestionnaireApiItem> Questionnaires { get; private set; }
    }
}
