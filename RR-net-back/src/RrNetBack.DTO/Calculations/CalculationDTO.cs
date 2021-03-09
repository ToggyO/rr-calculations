using System.Collections.Generic;

namespace RrNetBack.DTO.Calculations
{
    public class CalculationDTO
    {
        public string RollingRetention { get; set; }
        public IEnumerable<UserLifetimeDTO> UsersLifetime { get; set; }
    }
}