using AutoMapper;
using Domain.Commands.ReviewCommand;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
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
            await repository.CreateAsync(review);
        }

        public async Task<Review> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Review>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<Review> GetAsync(long id)
        {
            return await GetAsync(id);
        }
        public async Task<IList<Review>> ShowReviews(long id)
        {
            return await repository.ShowReviews(id);
        }

    }
}
