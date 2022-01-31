using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{
   public interface IPetRepository
    {
        Task CreateAsync(Pet pet);
        Task<IEnumerable<Pet>> GetAsync();
        Task<Pet> GetAsync(long id);
        Task<Pet> DeleteAsync(long id);
        Task UpdateAsync(Pet pet);
        
    }
}
