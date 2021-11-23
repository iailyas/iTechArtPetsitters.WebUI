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

        public ReviewService(IReviewRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(Review review)
        {
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
