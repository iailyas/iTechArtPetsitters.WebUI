
using DomainNew.Interfaces;
using DomainNew.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class PetsittingService : IPetsittingService
    {
        private readonly IPetsittingServiceService repository;

        public PetsittingService(IPetsittingServiceService repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(PetsittingService service)
        {

            await repository.CreateAsync(service);
        }

        public async Task<PetsittingService> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PetsittingService>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<PetsittingService> GetAsync(long id)
        {
            return await GetAsync(id);
        }

        public async Task UpdateAsunc(PetsittingService service)
        {
            return await repository.UpdateAsunc(service);
        }
    }
}
