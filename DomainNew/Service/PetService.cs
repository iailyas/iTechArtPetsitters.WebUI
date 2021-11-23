using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class PetService : IPetService
    {
        private readonly IPetRepository repository;

        public PetService(IPetRepository repository)
        {
            this.repository = repository;
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
