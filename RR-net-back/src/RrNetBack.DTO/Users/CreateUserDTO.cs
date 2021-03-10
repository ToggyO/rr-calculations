using System;

namespace RrNetBack.Domain.Models.Users
{
    public class CreateUserDTO
    {
        public DateTime RegistrationDate { get; set; }
        public DateTime LastActivityDate { get; set; }
    }
}