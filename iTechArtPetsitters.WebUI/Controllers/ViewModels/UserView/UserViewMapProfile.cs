using AutoMapper;
using DomainNew.Models;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.UserView
{
    public class UserViewMapProfile : Profile
    {
        public UserViewMapProfile()
        {
            CreateMap<UserView, User>().ReverseMap();
        }
    }
}
