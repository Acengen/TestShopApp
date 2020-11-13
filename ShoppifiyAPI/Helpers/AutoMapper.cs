using AutoMapper;
using ShoppifiyAPI.Dtos;
using ShoppifiyAPI.Models;

namespace ShoppifiyAPI.Helpers
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<ProductDto,Product>();
            CreateMap<Product,ProductDto>();

            CreateMap<UserDto,User>();
            CreateMap<User,UserDto>();

            CreateMap<ProductAndUserDto,ProductAndUser>();
            CreateMap<ProductAndUser,ProductAndUserDto>();

            CreateMap<UserToUpdateDto,User>();

            CreateMap<UserToCreateDto,User>();
            CreateMap<User,UserToCreateDto>();
        }
    }
}