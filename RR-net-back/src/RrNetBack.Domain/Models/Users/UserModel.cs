using System;

namespace RrNetBack.Domain.Models.Users {
    public class UserModel : BaseModel
    {
        public int Id { get; set; }
        public DateTime RegistrationDate { get; set; }
        public DateTime LastActivityDate { get; set; }
    }
}