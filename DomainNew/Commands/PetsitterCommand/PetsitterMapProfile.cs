using AutoMapper;
using DomainNew.Models;

namespace Domain.Commands.PetsitterCommand
{
    public class PetsitterMapProfile:Profile
    {
        public PetsitterMapProfile() 
        {
            CreateMap<Petsitter, AddPetsitterCommand>().ReverseMap();
        }
    }
}
