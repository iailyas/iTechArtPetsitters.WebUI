using DomainNew.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureNew.EFDbContext
{
    //context class (for access to the data in tables)
    public class EFServiceDBContext : DbContext
    {
        public EFServiceDBContext(DbContextOptions<EFServiceDBContext> options) : base(options) { }
        public DbSet<PetsittingJob> Services { get; set; }

    }

}


