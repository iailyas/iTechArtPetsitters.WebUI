using DomainNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Commands.PetCommand
{
    public class UpdatePetCommand
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Breed { get; set; }
        public float Weight { get; set; }
        public string Adress { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public long FileId { get; set; }
    }
}
