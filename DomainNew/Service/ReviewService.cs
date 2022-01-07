using AutoMapper;
using Domain.Commands.ReviewCommand;
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

        public ReviewService(IReviewRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task CreateAsync(AddReviewCommand addReviewCommand)
        {
            Review review = mapper.Map<Review>(addReviewCommand);
            if (review == null)
            {
               throw new Exception("Exception while creating a Review.");
            }
            await repository.CreateAsync(review);
        }

        public async Task<Review> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Review>> GetAsync()
        {
            var reviews = await GetAsync();
            if (reviews == null)
            {
                throw new Exception("Exception while accessing the Reviews.");
            }
            return await repository.GetAsync();
        }

        public async Task<Review> GetAsync(long id)
        {
            var review = await GetAsync(id);
            if (review == null)
            {
                throw new Exception("Exception while accessing a Review.");
            }
            return review;
        }
        public async Task<IList<Review>> ShowReviews(long id)
        {
            return await repository.ShowReviews(id);
        }

    }
}
