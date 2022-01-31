using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfrastructureNew.Repositories
{
    public class EFPetsittingJobServiceRepository : IPetsittingJobRepository
    {

        private EFMainDbContext Context;
        //contructor
        public EFPetsittingJobServiceRepository(EFMainDbContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<PetsittingJob>> GetAsync()
        {
            return await Context.Services.AsNoTracking().ToListAsync();
        }

        public async Task<PetsittingJob> GetAsync(long id)
        {
            return await Context.Services.AsNoTracking().SingleAsync(b => b.Id == id);
        }

        public async Task CreateAsync(PetsittingJob _service)
        {
            await Context.Services.AddAsync(_service);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PetsittingJob _service)
        {
            PetsittingJob currentService = _service;
            Context.Update(currentService);
            await Context.SaveChangesAsync();

        }

        public async Task<PetsittingJob> DeleteAsync(long id)
        {
            PetsittingJob service = await Context.Services.FindAsync(id);

            if (service != null)
            {
                Context.Remove(service);
                await Context.SaveChangesAsync();
            }

            return service;
        }
    }
}
