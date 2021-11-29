namespace Domain.Commands.PetsittingJobCommand
{
    public class AddPetsittingJobCommand
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
