using System;
using System.Collections.Generic;
using RrNetBack.DTO;
using RrNetBack.DTO.Calculations;

namespace RrNetBack.BLL.Services.Retention.Implementation
{
    public class RetentionService : IRetentionService
    {
        public string CalculateRollingRetention(ushort uniqueUsersCount, ushort totalUsersCount)
        {
            double rr = Math.Round((double) uniqueUsersCount / totalUsersCount * 100);
            return $"{rr} %";
        }

        public IEnumerable<UserLifetimeDTO> CreateUsersLifetimeInfo(DateTime startDate,
            DateTime endDate, IEnumerable<UserDTO> userDtoList)
        {
            if (startDate > endDate)
                return null;

            List<UserLifetimeDTO> userLifetimeDtos = new List<UserLifetimeDTO>();
            foreach (var date in CreateDateRange(startDate, endDate))
            {
                ushort count = 0;
                foreach (var userDto in userDtoList)
                {
                    if (date >= userDto.RegistartionDate && date <= userDto.LastActivityDate)
                        count++;
                }

                var userLifetimeDto = new UserLifetimeDTO
                {
                    AliveUsersCount = count,
                    Date = date,
                };
                userLifetimeDtos.Add(userLifetimeDto);
            }

            return userLifetimeDtos;
        }

        private IEnumerable<DateTime> CreateDateRange(DateTime startPoint, DateTime endPoint)
        {
            for (var day = startPoint.Date; day.Date <= endPoint.Date; day = day.AddDays(1))
                yield return day;
        }
    }
}