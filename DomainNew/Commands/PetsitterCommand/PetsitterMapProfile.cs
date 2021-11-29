using AutoMapper;
using DomainNew.Models;

namespace Domain.Commands.PetsitterCommand
{
    public class PetsitterMapProfile:Profile
    {
        PetsitterMapProfile() 
        {
            CreateMap<Petsitter, AddPetsitterCommand>().ReverseMap();
        }
    }
}
