using AutoMapper;
using DomainNew.Models;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.PetsitterView
{
    public class PetsitterViewMapProfile : Profile
    {
        public PetsitterViewMapProfile()
        {
            CreateMap<Petsitter, PetsitterView>().ReverseMap();
        }
    }
}
