using System;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class UserApiDetails
    {
        [DataMember]
        public bool IsArchived { get; set; }

        [DataMember]
        public Guid UserId { get; private set; }

        [DataMember]
        public string UserName { get; private set; }

        [DataMember]
        public UserRoles Role { get; private set; }

        [DataMember]
        public bool IsLocked { get; private set; }

        [DataMember]
        public DateTime CreationDate { get; private set; }

        [DataMember]
        public string Email { get; private set; }

        [DataMember]
        public string PhoneNumber { get; private set; }

        [DataMember]
        public string FullName { get; private set; }
    }
}
