using DomainNew.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureNew.EFDbContext
{
    public class EFMainDbContext : DbContext
    {
        public EFMainDbContext(DbContextOptions<EFMainDbContext> options) : base(options)
        { }
        public DbSet<Petsitter> Petsitters { get; set; }
        public DbSet<Petsitter> Applications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PetsittingJob> Services { get; set; }

    }
}
