using DomainNew.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureNew.EFDbContext
{
    class EFMyPetsitterDBContext : DbContext
    {
        public EFMyPetsitterDBContext(DbContextOptions<EFMyPetsitterDBContext> options) : base(options)
        { }
        public DbSet<MyPetsitter> Petsitters { get; set; }
    }
}
