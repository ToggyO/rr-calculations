using System;

namespace RrNetBack.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastActivityDate { get; set; }
    }
}