using DomainNew.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureNew.EFDbContext
{
    public class EFReviewDBContext : DbContext
    {
        public EFReviewDBContext(DbContextOptions<EFReviewDBContext> options) : base(options)
        { }
        public DbSet<Review> Reviews { get; set; }
    }
}
