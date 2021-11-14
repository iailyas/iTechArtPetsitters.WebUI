using System;

namespace DomainNew.Models
{
    public class Review
    {
        public long id { get; set; }
        public int User_id { get; set; }
        public int Petsitter_id { get; set; }
        public DateTime date { get; set; }


    }
}
