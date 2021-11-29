using AutoMapper;
using DomainNew.Models;

namespace Domain.Commands.ReviewCommand
{
    public class ReviewMapProfile:Profile
    {
        ReviewMapProfile() 
        {
            CreateMap<Review, AddReviewCommand>().ReverseMap();
        }
    }
}
