using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> Get();
        Task<Review> GetAsync(long id);
        Task CreateAsync(Review review);
        Task<Review> DeleteAsync(long id);
    }
}
