using AutoMapper;
using veso_be.Dtos;
using veso_be.Entities;
 
namespace veso_be.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();
        }
    }
}