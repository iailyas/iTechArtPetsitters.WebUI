using AutoMapper;
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
