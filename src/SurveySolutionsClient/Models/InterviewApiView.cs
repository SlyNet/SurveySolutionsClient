using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class InterviewApiView : BaseApiView
    {
        public IEnumerable<InterviewApiItem> Interviews { get; private set; }
    }
}
