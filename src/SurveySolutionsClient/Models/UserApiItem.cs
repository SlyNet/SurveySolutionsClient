using System;
using System.Runtime.Serialization;

namespace SurveySolutionsClient.Models
{
    public class UserApiItem
    {
        public bool IsLocked { get; set; }

        public DateTime CreationDate { get; set; }

        public string Email { get; set; }

        public string DeviceId { get; set; }

        public Guid UserId { get; set; }
        
        public string UserName { get; set; }
    }
}