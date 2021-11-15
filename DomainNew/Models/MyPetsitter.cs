using System.Collections.Generic;

namespace DomainNew.Models
{
    public class MyPetsitter
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        IList<Review> Reviews { get; set; }
    }
}
