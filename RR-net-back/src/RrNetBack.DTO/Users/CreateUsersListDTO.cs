using System.Collections.Generic;
using RrNetBack.Domain.Models.Users;

namespace RrNetBack.DTO.Users
{
    public class CreateUsersListDTO
    {
        public IEnumerable<CreateUserDTO> Users { get; set; } 
    }
}