using AutoMapper;
using DomainNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.PetsittingJobView
{
    public class PetsittingJobView
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
