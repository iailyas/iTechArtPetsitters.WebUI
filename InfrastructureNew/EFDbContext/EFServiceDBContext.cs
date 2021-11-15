using DomainNew.Models;
using InfrastructureNew.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace InfrastructureNew.EFDbContext
{
    //context class (for access to the data in tables)
    public class EFServiceDBContext : DbContext
    {
        public EFServiceDBContext(DbContextOptions<EFServiceDBContext> options) : base(options) { }
        public DbSet<Service> Services { get; set; }

    }

}


