using System;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class UserApiItem
    {
        [DataMember]
        
        public bool IsLocked { get; private set; }

        [DataMember]
        
        public DateTime CreationDate { get; private set; }

        [DataMember]
        public string Email { get; private set; }

        [DataMember]
        public string DeviceId { get; private set; }

        [DataMember]
        
        public Guid UserId { get; private set; }

        [DataMember]
        
        public string UserName { get; private set; }
    }
}