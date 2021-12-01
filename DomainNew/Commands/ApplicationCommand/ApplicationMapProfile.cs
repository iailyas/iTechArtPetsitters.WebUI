using AutoMapper;
using DomainNew.Models;

namespace Domain.Commands.ApplicationCommand
{
    public class ApplicationMapProfile:Profile
    {
        public ApplicationMapProfile() 
        {
            CreateMap<Application,AddApplicationCommand>().ReverseMap();
            CreateMap<Application, SelectApplicationCommand>().ReverseMap();
        }
    }
}
