using AutoMapper;
using Domain.Commands.UserCommand;
using DomainNew.Models;

namespace DomainNew.Commands
{
    public class UserUpdateProfile : Profile
    {
        public UserUpdateProfile()
        {
            CreateMap<User, RegisterUserCommand>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();
        }
    }
}
