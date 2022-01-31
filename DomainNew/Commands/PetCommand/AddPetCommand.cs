﻿using DomainNew.Models;

namespace Domain.Commands.PetCommand
{
    public class AddPetCommand
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
