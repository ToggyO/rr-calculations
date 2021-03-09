using AutoMapper;
using RrNetBack.Domain.Models.Users;
using RrNetBack.DTO;

namespace RrNetBack.BLL.Mappings.Profiles
{
    public class UserMapperProfile : Profile
    {
        public UserMapperProfile()
        {
            CreateMap<UserModel, UserDTO>().ReverseMap();
            CreateMap<UserModel, CreateUserDTO>().ReverseMap();
            CreateMap<UserModel, int>().ConvertUsing(o => o.Id);
        }
    }
}