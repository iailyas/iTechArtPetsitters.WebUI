using DomainNew.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureNew.EFDbContext
{
    //context class (for access to the data in tables)
    class EFServiceDBContext : DbContext
    {
        public EFServiceDBContext(DbContextOptions<EFServiceDBContext> options) : base(options) { }
        public DbSet<Service> Services { get; set; }

    }

}


