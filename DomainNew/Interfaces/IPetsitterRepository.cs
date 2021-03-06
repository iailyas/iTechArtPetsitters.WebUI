using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{
    public interface IPetsitterRepository
    {
        Task<IEnumerable<Petsitter>> GetAsync();
        Task<Petsitter> GetAsync(long id);
        Task CreateAsync(Petsitter petsitter);
        Task<Petsitter> DeleteAsync(long id);
    }
}
