


using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFDbContext
{
    public class EFUserDBContext : DbContext
    {
        public EFUserDBContext(DbContextOptions<EFUserDBContext> options) : base(options)
        { }
        public DbSet<MyUser> Users { get; set; }
        public object MyUser { get; internal set; }
    }
}
