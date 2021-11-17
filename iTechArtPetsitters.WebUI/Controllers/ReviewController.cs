using DomainNew.Interfaces;
using DomainNew.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPetsitters.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private IReviewRepository ReviewRepository;
        public ReviewController(IReviewRepository reviewRepository)
        {
            ReviewRepository = reviewRepository;
        }

        
        [HttpGet(Name = "GetAllReviews")]
        public async Task<IEnumerable<Review>> GetAsync()
        {
            return await  ReviewRepository.GetAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            Review review = await ReviewRepository .GetAsync(id);

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
            await ReviewRepository.CreateAsync(review);
            //return CreatedAtRoute("GetReview", new { Id = review.Id }, review);
            return Ok();
        }
       
        [HttpDelete("{id::long}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            var DeletedReview = await ReviewRepository.DeleteAsync(id);

            if (DeletedReview == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedReview);
        }
    }
}
