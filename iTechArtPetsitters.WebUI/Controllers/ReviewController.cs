using AutoMapper;
using Domain.Commands.ReviewCommand;
using DomainNew.Service.Interfaces;
using iTechArtPetsitters.WebUI.Controllers.ViewModels.ReviewView;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IMapper mapper;

        public ReviewController(IReviewService reviewService, IMapper mapper)
        {
            this.reviewService = reviewService;
            this.mapper = mapper;
        }

        [HttpGet(Name = "GetAllReviews")]
        public async Task<IEnumerable<ReviewView>> GetAsync()
        {
            IEnumerable<ReviewView> reviewView = mapper.Map<List<ReviewView>>(await reviewService.GetAsync());
            return reviewView;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            ReviewView reviewView = mapper.Map<ReviewView>(await reviewService.GetAsync(id));
            return new ObjectResult(reviewView);

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddReviewCommand addReviewCommand)
        {
            await reviewService.CreateAsync(addReviewCommand);
            return Ok();
        }

        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync()
        {
            ReviewView DeletedReview = mapper.Map<ReviewView>(await reviewService.DeleteAsync());
            return new ObjectResult(DeletedReview);
        }


    }
}
