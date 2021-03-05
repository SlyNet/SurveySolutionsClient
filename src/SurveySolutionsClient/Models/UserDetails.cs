using System;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class UserDetails
    {
        public bool IsArchived { get; set; }

        public Guid UserId { get; set; }

        public string UserName { get; set; }

        public UserRoles Role { get; set; }

        public bool IsLocked { get; set; }

        public DateTime CreationDate { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string FullName { get; set; }
    }
}
