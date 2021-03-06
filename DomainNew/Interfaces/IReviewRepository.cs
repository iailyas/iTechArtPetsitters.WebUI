using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAsync();
        Task<Review> GetAsync(long id);
        Task CreateAsync(Review review);
        Task<Review> DeleteAsync(long id);
        Task<IList<Review>> ShowReviews(long id);
    }
}
