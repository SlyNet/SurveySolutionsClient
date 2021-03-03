using System.Collections.Generic;

namespace SurveySolutionsClient.Models
{
    /// <summary>
    /// List of users
    /// </summary>
    /// <seealso cref="SurveySolutionsClient.Models.BaseList" />
    public class UserList : BaseList
    {
        /// <summary>
        /// Gets or sets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public IEnumerable<UserApiItem> Users { get; set; }
    }
}
