using AutoMapper;
using Domain.Interfaces.CurrentUsers;
using DomainNew.Models;

namespace Domain.Interfaces.CurrentUser.CurrentUserViews
{
    public class CurrentUserViewMapProfile : Profile
    {
        public CurrentUserViewMapProfile()
        {
            CreateMap<User, CurrentUserView>().ReverseMap();
        }
    }
}
