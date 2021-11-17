using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfrastructureNew.Repositories
{
    public class EFServiceRepository:IServiceRepository
    {
        
            private EFMainDbContext Context;
            //contructor
            public EFServiceRepository(EFMainDbContext context)
            {
                Context = context;
            }
            public async Task<IEnumerable<Service>> GetAsync()
            {
                return await Context.Services.ToListAsync();
            }

            public async Task<Service> GetAsync(long id)
            {
                return await Context.Services.FindAsync(id);
            }

            public async Task CreateAsync(Service _service)
            {
                await Context.Services.AddAsync(_service);
                await Context.SaveChangesAsync();
            }

            public async Task UpdateAsunc(Service _service)
            {
                Service currentService = _service;
                Context.Update(currentService);
                await Context.SaveChangesAsync();

            }

            public async Task<Service> DeleteAsync(long id)
            {
                Service service = await Context.Services.FindAsync(id);

                if (service != null)
                {
                    Context.Remove(service);
                    await Context.SaveChangesAsync();
                }

                return service;
            }
        
    }
}
