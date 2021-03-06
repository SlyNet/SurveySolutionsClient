﻿using System.ComponentModel;
using System.Text.Json.Serialization;

namespace SurveySolutionsClient.Models
{
    public class RegisterUserModel
    {
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Roles Role { get; set; } = Roles.Interviewer;

        
        public string UserName { get; set; }

        public string? FullName { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the supervisor login if interviewer is created.
        /// </summary>
        /// <value>
        /// The supervisor.
        /// </value>
        public string? Supervisor { get; set; }

    }
}
