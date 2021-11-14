using DomainNew.Models;
using System.Collections.Generic;

namespace DomainNew.Interfaces
{
    public interface IReviewRepository
    {
        IEnumerable<Review> Get();
        Review Get(long id);
        void Create(Review review);
        Review Delete(long id);
    }
}
