using AutoMapper;
using DomainNew.Models;

namespace Domain.Commands.ReviewCommand
{
    public class ReviewMapProfile:Profile
    {
        public ReviewMapProfile() 
        {
            CreateMap<Review,AddReviewCommand >().ReverseMap();
        }
    }
}
