using AutoMapper;
using DomainNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.UserView
{
    public class UserViewMapProfile:Profile
    {
        public UserViewMapProfile() 
        {
            CreateMap<UserView, User>().ReverseMap();
        }
    }
}
