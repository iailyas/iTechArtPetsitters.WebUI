using DomainNew.Models;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class PetService : Interfaces.IPetService
    {
        private readonly DomainNew.Interfaces.IPetService repository;

        public PetService(DomainNew.Interfaces.IPetService repository)
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
