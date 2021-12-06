using AutoMapper;
using DomainNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.ApplicationView
{
    public class ApplicationViewMapProfile:Profile
    {
        public ApplicationViewMapProfile()
        {
            CreateMap<Application, ApplicationView>().ReverseMap();
        }
    }
}
