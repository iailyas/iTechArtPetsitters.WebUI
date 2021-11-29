using AutoMapper;
using DomainNew.Models;

namespace Domain.Commands.PetCommand
{
    public class PetMapProfile : Profile
    {
        PetMapProfile()
        {
            CreateMap<Pet, AddPetCommand>().ReverseMap();
        }
    }
}
