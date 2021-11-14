using DomainNew.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFDbContext
{
    //context class (for access to the data in tables)
    public class EFMyUserDBContext : DbContext
    {
        public EFMyUserDBContext(DbContextOptions<EFMyUserDBContext> options) : base(options)
        { }
        public DbSet<MyUser> Users { get; set; }

    }
}
