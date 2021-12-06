using AutoMapper;
using DomainNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.ReviewView
{
    public class ReviewViewMapProfile:Profile
    {
        public ReviewViewMapProfile()
        {
            CreateMap<ReviewView, Review>();
        }
    }
}
