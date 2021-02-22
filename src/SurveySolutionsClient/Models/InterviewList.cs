using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class InterviewList : BaseList
    {
        public IEnumerable<InterviewApiItem> Interviews { get; private set; }
    }
}
