using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using System;
using System.Collections.Generic;

namespace InfrastructureNew.Repositories
{
    public class EFReviewRepository : IReviewRepository
    {
        private EFMainDbContext context;

        public EFReviewRepository(EFMainDbContext context)
        {
            this.context = context;
        }
        public void Create(Review review)
        {
            context.Reviews.Add(review);
            context.SaveChanges();
        }

        public Review Delete(long id)
        {
            Review review = context.Reviews.Find(id);

            if (review != null)
            {
                context.Remove(review);
                context.SaveChanges();
            }

            return review;
        }

       public IEnumerable<Review> Get()
        {
            return context.Reviews; /// .ToList?
        }

        public Review Get(long id)
        {
            return context.Reviews.Find(id);
        }

        
    }
}
