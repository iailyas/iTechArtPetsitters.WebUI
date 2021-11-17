using DomainNew.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureNew.EFDbContext
{
    class EFPetsitterDBContext : DbContext
    {
        public EFPetsitterDBContext(DbContextOptions<EFPetsitterDBContext> options) : base(options)
        { }
        public DbSet<Petsitter> Petsitters { get; set; }
    }
}
