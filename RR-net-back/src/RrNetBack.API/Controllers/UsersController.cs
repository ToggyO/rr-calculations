using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RrNetBack.API.Handlers.Users;
using RrNetBack.Common.Models.Pagination;
using RrNetBack.Common.Response;
using RrNetBack.DTO;
using RrNetBack.DTO.Calculations;
using RrNetBack.DTO.Users;

namespace RrNetBack.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersHandler _handler;

        public UsersController(IUsersHandler handler)
        {
            _handler = handler;
        }

        [HttpGet]
        public async Task<Response<PaginationModel<UserDTO>>> GetList([FromQuery] PaginationModel model)
        {
            return await _handler.GetList(model);
        }
        
        [HttpPost]
        public async Task<Response> RewriteUsers([Required, FromBody] CreateUsersListDTO model)
        {
            return await _handler.RewriteUsers(model.Users);
        }

        [HttpGet("calculate")]
        public async Task<Response<CalculationDTO>> Calculate()
        {
            return await _handler.Calculate();
        }
    }
}