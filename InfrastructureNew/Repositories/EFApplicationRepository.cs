using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfrastructureNew.Repositories
{
    public class EFApplicationRepository : IApplicationRepository
    {
        private readonly EFMainDbContext context;

        public EFApplicationRepository(EFMainDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(Petsitter application)
        {
            context.Applications.Add(application);
            await context.SaveChangesAsync();
        }

        public async Task<Petsitter> DeleteAsync(long id)
        {
            Petsitter application = await context.Applications.FindAsync(id);

            if (application != null)
            {
                context.Remove(application);
                await context.SaveChangesAsync();
            }

            return application;
        }

        public async Task<IEnumerable<Petsitter>> GetAsync()
        {
            return await context.Applications.ToListAsync();
        }

        public async Task<Petsitter> GetAsync(long id)
        {
            return await context.Applications.FindAsync(id);
        }
    }
}
