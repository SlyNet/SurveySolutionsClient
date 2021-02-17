using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class UserApiView : BaseApiView
    {
        public IEnumerable<UserApiItem> Users { get; private set; }
    }
}
