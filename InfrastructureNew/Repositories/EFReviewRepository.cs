using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfrastructureNew.Repositories
{
    public class EFReviewRepository : IReviewService
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

        public async Task<IEnumerable<Review>> GetAsync()
        {
            return await context.Reviews.ToListAsync();
        }

        public async Task<Review> GetAsync(long id)
        {
            return await context.Reviews.FindAsync(id);
        }


    }
}
