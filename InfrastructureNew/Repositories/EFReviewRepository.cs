using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfrastructureNew.Repositories
{
    public class EFReviewRepository : IReviewRepository
    {
        private EFMainDbContext context;

        public EFReviewRepository(EFMainDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(Review review)
        {
            await context.Reviews.AddAsync(review);
            await context.SaveChangesAsync();
        }

        public async Task<Review> DeleteAsync(long id)
        {
            Review review = await context.Reviews.FindAsync(id);

            if (review != null)
            {
                context.Remove(review);
                await context.SaveChangesAsync();
            }

            return review;
        }

       public IEnumerable<Review> Get()
        {
            return context.Reviews; /// .ToList?
        }

        public async Task<Review> GetAsync(long id)
        {
            return await context.Reviews.FindAsync(id);
        }

        
    }
}
