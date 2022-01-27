using AutoMapper;
using DomainNew.Models;

namespace iTechArtPetsitters.WebUI.Controllers.ViewModels.ReviewView
{
    public class ReviewViewMapProfile : Profile
    {
        public ReviewViewMapProfile()
        {
            CreateMap<ReviewView, Review>().ReverseMap();
        }
    }
}
