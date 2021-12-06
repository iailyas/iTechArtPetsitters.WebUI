using DomainNew.Models;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.ApplicationView
{
    public class ApplicationView
    {
        public long Id { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int PetsitterId { get; set; }
        public Petsitter Petsitter { get; set; }
        public int ServiceId { get; set; }
        public PetsittingJob Service { get; set; }
    }
}
