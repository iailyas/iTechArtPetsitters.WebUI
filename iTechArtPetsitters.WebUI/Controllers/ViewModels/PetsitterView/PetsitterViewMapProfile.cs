using AutoMapper;
using DomainNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.PetsitterView
{
    public class PetsitterViewMapProfile:Profile
    {
        public PetsitterViewMapProfile()
        {
            CreateMap<Petsitter, PetsitterView>().ReverseMap();
        }
    }
}
