using Domain.Service;
using DomainNew.Models;
using System;

namespace Domain.Commands.ReviewCommand
{
    public class AddReviewCommand
    {
        public CurrentUserService currentUserService;

        public long Id => currentUserService.GetCurrentUser().Id;
        public int UserId { get; set; }
        public User User { get; set; }
        public int PetsitterId { get; set; }
        public Petsitter Petsitter { get; set; }
        public DateTime Date { get; set; }
    }
}
