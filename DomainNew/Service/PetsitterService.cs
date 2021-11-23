using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class PetsitterService : IPetsitterService
    {
        private readonly IPetsitterRepository repository;

        public PetsitterService(IPetsitterRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(Petsitter petsitter)
        {
            await repository.CreateAsync(petsitter);
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
