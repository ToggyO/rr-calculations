using System.Collections.Generic;
using System.Threading.Tasks;
using RrNetBack.Common.Models.Pagination;
using RrNetBack.Common.Response;
using RrNetBack.Domain.Models.Users;
using RrNetBack.DTO;
using RrNetBack.DTO.Calculations;

namespace RrNetBack.API.Handlers.Users
{
    public interface IUsersHandler
    {
        Task<Response<PaginationModel<UserDTO>>> GetList(PaginationModel model);
        Task<Response> RewriteUsers(IEnumerable<CreateUserDTO> dtoList);
        Task<Response<CalculationDTO>> Calculate();
    }
}