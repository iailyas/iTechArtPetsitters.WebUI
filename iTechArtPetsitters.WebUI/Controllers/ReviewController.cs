using DomainNew.Interfaces;
using DomainNew.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private IReviewService ReviewService;
        public ReviewController(IReviewService review)
        {
            ReviewService = review;
        }


        [HttpGet(Name = "GetAllReviews")]
        public async Task<IEnumerable<Review>> GetAsync()
        {
            return await ReviewService.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            Review review = await ReviewService.GetAsync(id);

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
            await ReviewService.CreateAsync(review);
            //return CreatedAtRoute("GetReview", new { Id = review.Id }, review);
            return Ok();
        }

        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var DeletedReview = await ReviewService.DeleteAsync(id);

            if (DeletedReview == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedReview);
        }
    }
}
