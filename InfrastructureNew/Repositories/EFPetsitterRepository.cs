using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfrastructureNew.Repositories
{
    public class EFPetsitterRepository : IPetsitterRepository
    {
        private readonly EFMainDbContext context;

        public EFPetsitterRepository(EFMainDbContext context)
        {
            this.context = context;
        }

        public async Task CreateAsync(Petsitter petsitter)
        {
            context.Petsitters.Add(petsitter);
            await context.SaveChangesAsync();
        }

        public async Task<Petsitter> DeleteAsync(long id)
        {
            Petsitter petsitter = await context.Petsitters.FindAsync(id);

            if (petsitter != null)
            {
                context.Remove(petsitter);
                await context.SaveChangesAsync();
            }

            return petsitter;
        }

        public async Task<IEnumerable<Petsitter>> GetAsync()
        {
            return await context.Petsitters.ToListAsync();
        }

        public async Task<Petsitter> GetAsync(long id)
        {
            return await context.Petsitters.FindAsync(id);
        }

    }
}
