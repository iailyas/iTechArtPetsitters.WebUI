using AutoMapper;
using Domain.Interfaces.CurrentUsers;
using DomainNew.Models;

namespace Domain.Views.CurrentUserView
{
    public class CurrentUserViewMapProfile : Profile
    {
        public CurrentUserViewMapProfile()
        {
            CreateMap<User, CurrentUserView>().ReverseMap();
        }
    }
}
