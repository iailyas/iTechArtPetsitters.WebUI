using DomainNew.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureNew.EFDbContext
{
    public class EFPetDBContext : DbContext
    {
        public EFPetDBContext(DbContextOptions<EFPetDBContext> options) : base(options) { }
        public DbSet<Pet> Pets { get; set; }
    }
}
