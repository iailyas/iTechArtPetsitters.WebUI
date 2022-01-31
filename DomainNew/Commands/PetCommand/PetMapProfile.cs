using AutoMapper;
using DomainNew.Models;

namespace Domain.Commands.PetCommand
{
    public class PetMapProfile : Profile
    {
        public PetMapProfile()
        {
            CreateMap<Pet, AddPetCommand>().ReverseMap();
            CreateMap<Pet, UpdatePetCommand>().ReverseMap();
        }
    }
}
