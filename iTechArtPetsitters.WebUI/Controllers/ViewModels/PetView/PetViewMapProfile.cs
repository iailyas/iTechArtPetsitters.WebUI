using AutoMapper;
using DomainNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.PetView
{
    public class PetViewMapProfile:Profile
    {
        public PetViewMapProfile()
        {
            CreateMap<Pet, PetView>().ReverseMap();
        }
    }
}
