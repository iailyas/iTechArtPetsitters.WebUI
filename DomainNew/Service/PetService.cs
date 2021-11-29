using DomainNew.Commands;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{

    public class PetService : IPetService
    {
        private readonly IPetRepository repository;
        private readonly UserUpdateProfile userUpdate;
        public PetService(IPetRepository repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Pet>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<Pet> GetAsync(long id)
        {
            return await repository.GetAsync(id);
        }

        public async Task CreateAsync(Pet pet)
        {
            await repository.CreateAsync(pet);
        }

        public Task<Pet> DeleteAsync(long id)
        {
            return repository.DeleteAsync(id);
        }
    }
}
