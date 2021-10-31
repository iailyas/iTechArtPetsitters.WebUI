

using Microsoft.Azure.Documents;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFDbContext
{
    class EFUserDBContext : DbContext
    {
        public EFUserDBContext(DbContextOptions<EFUserDBContext> options) : base(options)
        { }
        public DbSet<User> Users { get; set; }
       
    }
}
