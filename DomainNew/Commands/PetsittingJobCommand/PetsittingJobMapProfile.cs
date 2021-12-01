using AutoMapper;
using DomainNew.Models;

namespace Domain.Commands.PetsittingJobCommand
{
    public class PetsittingJobMapProfile:Profile
    {
        public PetsittingJobMapProfile()
        {
            CreateMap<PetsittingJob, AddPetsittingJobCommand>().ReverseMap();
            CreateMap<PetsittingJob, UpdatePetsittingJobCommand>().ReverseMap();
        }
    }
}
