namespace DomainNew.Models
{
    public class Application
    {
        public long Id { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int PetsitterId { get; set; }
        public Petsitter Petsitter { get; set; }
        public int ServiceId { get; set; }
        public Service Service { get; set; }
    }
}
