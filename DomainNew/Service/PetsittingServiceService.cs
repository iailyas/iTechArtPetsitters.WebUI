
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{

    public class PetsittingServiceService : IPetsittingServiceService
    {
        private readonly IPetsittingService repository;

        public PetsittingServiceService(IPetsittingService repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(PetsittingJob service)
        {

            await repository.CreateAsync(service);
        }

        public async Task<PetsittingJob> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PetsittingJob>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<PetsittingJob> GetAsync(long id)
        {
            return await GetAsync(id);
        }

        public async Task UpdateAsunc(PetsittingJob service)
        {
           await repository.UpdateAsunc(service);
        }
    }
}
