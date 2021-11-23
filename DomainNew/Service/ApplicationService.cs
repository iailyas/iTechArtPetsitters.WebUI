using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class PetsitterApplication : IApplicationService
    {
        private readonly IApplicationRepository repository;

        public PetsitterApplication(IApplicationRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(Petsitter application)
        {
            await repository.CreateAsync(application);
        }

        public async Task<Petsitter> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Petsitter>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<Petsitter> GetAsync(long id)
        {
            return await repository.GetAsync(id);
        }
    }
}
