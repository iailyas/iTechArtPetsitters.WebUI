using AutoMapper;
using DomainNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.PetsittingJobView
{
    public class PetsittingJobViewMapProfile:Profile
    {
        public PetsittingJobViewMapProfile()
        {
            CreateMap<PetsittingJob, PetsittingJobView>().ReverseMap();
        }
    }
}
