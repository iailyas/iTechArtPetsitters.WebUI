using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class ReviewService : Interfaces.IReviewService
    {
        private readonly DomainNew.Interfaces.IReviewService repository;

        public ReviewService(DomainNew.Interfaces.IReviewService repository)
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
    }
}
