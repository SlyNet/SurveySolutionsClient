using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    public class UserList : BaseList
    {
        public IEnumerable<UserApiItem> Users { get; private set; }
    }
}
