using AutoMapper;
using Domain.Commands.ReviewCommand;
using DomainNew.Models;
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
        public ReviewController(IReviewService review,IMapper mapper)
        {
            reviewService = review;
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

            if (reviewView == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(reviewView);

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AddReviewCommand addReviewCommand)
        {
            if (addReviewCommand== null)
            {
                return BadRequest();
            }
            await reviewService.CreateAsync(addReviewCommand);
            //return CreatedAtRoute("GetReview", new { Id = review.Id }, review);
            return Ok();
        }

        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ReviewView DeletedReview = mapper.Map<ReviewView>(await reviewService.DeleteAsync(id));

            if (DeletedReview == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedReview);
        }


    }
}
