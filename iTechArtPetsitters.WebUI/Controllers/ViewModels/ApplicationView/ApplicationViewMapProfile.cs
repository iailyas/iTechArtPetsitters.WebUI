using AutoMapper;
using DomainNew.Models;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.ApplicationView
{
    public class ApplicationViewMapProfile : Profile
    {
        public ApplicationViewMapProfile()
        {
            CreateMap<Application, ApplicationView>().ReverseMap();
        }
    }
}
