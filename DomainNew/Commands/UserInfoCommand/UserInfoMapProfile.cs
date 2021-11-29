using AutoMapper;
using DomainNew.Models;

namespace Domain.Commands.UserInfoCommand
{
    public class UserInfoMapProfile:Profile
    {
        UserInfoMapProfile() 
        {
            CreateMap<UserInfo, AddUserInfoCommand>().ReverseMap();
        }
    }
}
