using System;
using System.Collections.Generic;
using RrNetBack.DTO;
using RrNetBack.DTO.Calculations;

namespace RrNetBack.BLL.Services.Retention
{
    public interface IRetentionService
    {
        string CalculateRollingRetention(ushort uniqueUsersCount, ushort totalUsersCount);

        IEnumerable<UserLifetimeDTO> CreateUsersLifetimeInfo(DateTime startDate,
            DateTime endDate, IEnumerable<UserDTO> userDtoList);
    }
}