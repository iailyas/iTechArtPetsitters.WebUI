using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfrastructureNew.Repositories
{
    public class EFPetsittingServiceRepository : IPetsittingServiceService
    {

        private EFMainDbContext Context;
        //contructor
        public EFPetsittingServiceRepository(EFMainDbContext context)
        {
            Context = context;
        }
        public async Task<IEnumerable<PetsittingService>> GetAsync()
        {
            return await Context.Services.ToListAsync();
        }

        public async Task<PetsittingService> GetAsync(long id)
        {
            return await Context.Services.FindAsync(id);
        }

        public async Task CreateAsync(PetsittingService _service)
        {
            await Context.Services.AddAsync(_service);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsunc(PetsittingService _service)
        {
            PetsittingService currentService = _service;
            Context.Update(currentService);
            await Context.SaveChangesAsync();

        }

        public async Task<PetsittingService> DeleteAsync(long id)
        {
            PetsittingService service = await Context.Services.FindAsync(id);

            if (service != null)
            {
                Context.Remove(service);
                await Context.SaveChangesAsync();
            }

            return service;
        }

    }
}
