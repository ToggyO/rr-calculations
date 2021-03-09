using System;

namespace RrNetBack.DTO.Calculations
{
    public class UserLifetimeDTO
    {
        public DateTime Date { get; set; } 
        public ushort AliveUsersCount { get; set; }
    }
}