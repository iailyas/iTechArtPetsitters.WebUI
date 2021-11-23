using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IPetsitterService
    {
        Task<IEnumerable<Petsitter>> GetAsync();
        Task<Petsitter> GetAsync(long id);
        Task CreateAsync(Petsitter petsitter);
        Task<Petsitter> DeleteAsync(long id);
        Task<Petsitter> SetApplication(long id);
    }
}
