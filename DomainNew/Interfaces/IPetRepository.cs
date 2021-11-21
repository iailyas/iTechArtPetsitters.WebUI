using DomainNew.Models;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{
   public interface IPetRepository
    {
        Task CreateAsync(Pet pet);
        Task<Pet> DeleteAsync(long id);
    }
}
