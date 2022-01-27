using AutoMapper;
using Domain.Commands.ReviewCommand;
using Domain.Service.Interfaces;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace DomainNew.Service
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository repository;
        private readonly IMapper mapper;
        private readonly ICurrentUserService currentUserService;

        public ReviewService(IReviewRepository repository, IMapper mapper, ICurrentUserService currentUserSerice)
        {
            this.repository = repository;
            this.mapper = mapper;
            this.currentUserService = currentUserSerice;
        }

        public async Task CreateAsync(AddReviewCommand addReviewCommand)
        {

            Review review = mapper.Map<Review>(addReviewCommand);
            review.UserId = currentUserService.GetCurrentUserId();
            if (review == null)
            {
                throw new Exception("Exception while creating a Review.");
            }
            await repository.CreateAsync(review);
        }

        public async Task<Review> DeleteAsync()
        {
            long id = currentUserService.GetCurrentUserId();
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Review>> GetAsync()
        {
            var reviews = await repository.GetAsync();
            if (reviews == null)
            {
                throw new Exception("Exception while accessing the Reviews.");
            }
            return reviews;
        }

        public async Task<Review> GetAsync(long id)
        {

            var review = await repository.GetAsync(id);
            if (review == null)
            {
                throw new Exception("Exception while accessing a Review.");
            }
            return review;
        }
        public async Task<IList<Review>> ShowReviews()
        {
            long id = currentUserService.GetCurrentUserId();
            return await repository.ShowReviews(id);
        }

    }
}
