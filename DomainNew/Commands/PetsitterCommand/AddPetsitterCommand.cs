using DomainNew.Models;
using System.Collections.Generic;

namespace Domain.Commands.PetsitterCommand
{
    public class AddPetsitterCommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        IList<Review> Reviews { get; set; }
    }
}
