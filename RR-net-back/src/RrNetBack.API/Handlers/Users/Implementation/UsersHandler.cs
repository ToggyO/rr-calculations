using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using RrNetBack.BLL.Services.Retention;
using RrNetBack.Common.Models.Pagination;
using RrNetBack.Common.Response;
using RrNetBack.DAL.Repository.Users;
using RrNetBack.Domain.Models.Users;
using RrNetBack.DTO;
using RrNetBack.DTO.Calculations;

namespace RrNetBack.API.Handlers.Users.Implementation
{
    public class UsersHandler : IUsersHandler
    {
        private readonly IUsersRepository _repository;
        private readonly IRetentionService _service;
        private readonly IMapper _mapper;

        public UsersHandler(IUsersRepository repository,
            IRetentionService service,
            IMapper mapper)
        {
            _repository = repository;
            _service = service;
            _mapper = mapper;
        }

        public async Task<Response<PaginationModel<UserDTO>>> GetList(PaginationModel model)
        {
            var page = await _repository.GetList(model, null, null);
            var result = new PaginationModel<UserDTO>
            {
                Page = page.Page,
                PageSize = page.PageSize,
                Total = page.Total,
                Items = _mapper.Map<IEnumerable<UserModel>, IEnumerable<UserDTO>>(page.Items),
            };
            return new Response<PaginationModel<UserDTO>>
            {
                ResultData = result,
            };
        }

        public async Task<Response> RewriteUsers(IEnumerable<CreateUserDTO> dtoList)
        {
            await ClearUsers();
            
            List<UserModel> users = new List<UserModel>();
            foreach (var userData in dtoList)
            {
                UserModel user = new UserModel
                {
                    RegistartionDate = userData.RegistartionDate,
                    LastActivityDate = userData.LastActivityDate,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                users.Add(user);
            }

            await _repository.CreateBulk(users);
            return new Response();
        }

        public async Task<Response<CalculationDTO>> Calculate()
        {
            var uniqueUsers = _repository.GetUsersByLifetime(7);
            var allUsers = await _repository.GetList(GetAllUsersQuery(), null, null);
            string rollingRetention = _service.CalculateRollingRetention((ushort)uniqueUsers.Count(), (ushort)allUsers.Total);

            var usersByReg = await _repository.GetList(GetAllUsersQuery(), true, null);
            var usersByLastActivity = await _repository.GetList(GetAllUsersQuery(), true, true);

            IEnumerable<UserDTO> userDtos = _mapper.Map<IEnumerable<UserModel>, IEnumerable<UserDTO>>(allUsers.Items);
            var result = _service.CreateUsersLifetimeInfo(usersByReg.Items.First().RegistartionDate,
                usersByLastActivity.Items.First().LastActivityDate, userDtos);
            
            var calculations =  new CalculationDTO
            {
                RollingRetention = rollingRetention,
                UsersLifetime = result,
            };
            return new Response<CalculationDTO>
            {
                ResultData = calculations,
            };
        }

        private PaginationModel GetAllUsersQuery() => new PaginationModel
        {
            Page = 1,
            PageSize = 9999,
        };
        
        private async Task ClearUsers()
        {
            var page = await _repository.GetList(GetAllUsersQuery(), null, null);
            await _repository.DeleteBulk(page.Items);
        }
    }
}