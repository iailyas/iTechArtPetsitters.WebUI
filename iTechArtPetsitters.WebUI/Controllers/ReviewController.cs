using DomainNew.Models;
using DomainNew.Service.Interfaces;
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
        public ReviewController(IReviewService review)
        {
            reviewService = review;
        }


        [HttpGet(Name = "GetAllReviews")]
        public async Task<IEnumerable<Review>> GetAsync()
        {
            return await reviewService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            Review review = await reviewService.GetAsync(id);

            if (review == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(review);

        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] Review review)
        {
            if (review == null)
            {
                return BadRequest();
            }
            await reviewService.CreateAsync(review);
            //return CreatedAtRoute("GetReview", new { Id = review.Id }, review);
            return Ok();
        }

        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var DeletedReview = await reviewService.DeleteAsync(id);

            if (DeletedReview == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedReview);
        }


    }
}
