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
        IReviewRepository ReviewRepository;
        public ReviewController(IReviewRepository reviewRepository)
        {
            ReviewRepository = reviewRepository;
        }

        
        [HttpGet(Name = "GetAll")]
        public IEnumerable<Review> Get()
        {
            return ReviewRepository.Get();
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            Review review = ReviewRepository.Get(id);

            if (review == null)
            {
                return NotFound(id.ToString());
            }

            return new ObjectResult(review);

        }
        [HttpPost]
        public IActionResult Create([FromBody] Review review)
        {
            if (review == null)
            {
                return BadRequest();
            }
            ReviewRepository.Create(review);
            return CreatedAtRoute("GetService", new { id = review.id }, review);
        }
       
        [HttpDelete("{id::long}")]
        public IActionResult Delete(long id)
        {
            var DeletedReview = ReviewRepository.Delete(id);

            if (DeletedReview == null)
            {
                return BadRequest();
            }

            return new ObjectResult(DeletedReview);
        }
    }
}
