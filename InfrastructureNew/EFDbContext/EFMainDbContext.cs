using Domain.Models;
using Domain.Models.Authentication;
using DomainNew.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureNew.EFDbContext
{
    public class EFMainDbContext : IdentityDbContext<ApplicationUser, UserRoles, long>
    {
        public EFMainDbContext(DbContextOptions<EFMainDbContext> options) : base(options)
        { }
        public DbSet<Petsitter> Petsitters { get; set; }
        public DbSet<Application> Applications { get; set; }
        public DbSet<User> Users{ get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<PetsittingJob> Services { get; set; }
        public DbSet<UserInfo> InformationAboutUser { get; set; }
        public DbSet<FileModel> files { get; set; }
       
    }
}
