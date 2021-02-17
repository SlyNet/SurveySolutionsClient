using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class QuestionnaireApiView : BaseApiView
    {
        
        public IEnumerable<QuestionnaireApiItem> Questionnaires { get; private set; }
    }
}
