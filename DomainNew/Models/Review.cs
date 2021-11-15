using System;

namespace DomainNew.Models
{
    public class Review
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int PetsitterId { get; set; }
        public MyPetsitter Petsitter { get; set; }
        public DateTime Date { get; set; }


    }
}
