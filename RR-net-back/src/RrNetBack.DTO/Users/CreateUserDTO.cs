using System;

namespace RrNetBack.Domain.Models.Users
{
    public class CreateUserDTO
    {
        public DateTime RegistartionDate { get; set; }
        public DateTime LastActivityDate { get; set; }
    }
}