using DomainNew.Models;

namespace Domain.Commands.ApplicationCommand
{
    public class AddApplicationCommand
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
