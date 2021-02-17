using System.ComponentModel;

namespace SurveySolutionsClient.Models
{
    public class RegisterUserModel
    {
        
        public Roles Role { get; set; }

        
        public string UserName { get; set; }

        public string FullName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        
        public string Password { get; set; }

        public string Supervisor { get; set; }

    }
}
