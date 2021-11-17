﻿using DomainNew.Models;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureNew.EFDbContext
{
    public class EFApplicationDBContext : DbContext
    {
        public EFApplicationDBContext(DbContextOptions<EFApplicationDBContext> options) : base(options)
        { }
        public DbSet<Application> Applications { get; set; }
    }
}