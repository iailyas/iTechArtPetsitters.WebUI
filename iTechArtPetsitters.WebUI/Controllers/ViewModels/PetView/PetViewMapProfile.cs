using AutoMapper;
using DomainNew.Models;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.PetView
{
    public class PetViewMapProfile : Profile
    {
        public PetViewMapProfile()
        {
            CreateMap<Pet, PetView>().ReverseMap();
        }
    }
}
