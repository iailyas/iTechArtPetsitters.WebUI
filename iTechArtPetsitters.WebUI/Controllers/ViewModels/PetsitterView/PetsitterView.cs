using DomainNew.Models;
using System.Collections.Generic;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.PetsitterView
{
    public class PetsitterView
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        IList<Review> Reviews { get; set; }
    }
}
