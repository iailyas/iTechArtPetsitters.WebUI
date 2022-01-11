using AutoMapper;
using Domain.Commands.ReviewCommand;
using DomainNew.Service.Interfaces;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.ReviewView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]

    [Authorize]
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IMapper mapper;
        public ReviewController(IReviewService review, IMapper mapper)
        {
            reviewService = review;
            this.mapper = mapper;
        }


        [HttpGet(Name = "GetAllReviews")]
        [Authorize(Roles = "Administrator")]
        public async Task<IEnumerable<ReviewView>> GetAsync()
        {
            IEnumerable<ReviewView> reviewView = mapper.Map<List<ReviewView>>(await reviewService.GetAsync());
            return reviewView;
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Petsitter")]
        public async Task<IActionResult> GetAsync(long id)
        {
            ReviewView reviewView = mapper.Map<ReviewView>(await reviewService.GetAsync(id));
            return new ObjectResult(reviewView);

        }
        [HttpPost]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateAsync([FromBody] AddReviewCommand addReviewCommand)
        {
            await reviewService.CreateAsync(addReviewCommand);
            return Ok();
        }

        [HttpDelete("{id::long}")]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ReviewView DeletedReview = mapper.Map<ReviewView>(await reviewService.DeleteAsync(id));
            return new ObjectResult(DeletedReview);
        }


    }
}
