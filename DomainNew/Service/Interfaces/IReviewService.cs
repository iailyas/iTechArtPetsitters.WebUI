using Domain.Commands.ReviewCommand;
using Domain.Service.Interfaces;
using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IReviewService
    {
        Task<IEnumerable<Review>> GetAsync();
        Task<Review> GetAsync(long id);
        Task CreateAsync(AddReviewCommand addReviewCommand);
        Task<Review> DeleteAsync();
        Task<IList<Review>> ShowReviews();
    }
}
