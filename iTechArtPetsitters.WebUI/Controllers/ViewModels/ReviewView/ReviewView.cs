using DomainNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.ReviewView
{
    public class ReviewView
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PetsitterId { get; set; }
        public Petsitter Petsitter { get; set; }
        public DateTime Date { get; set; }
    }
}
