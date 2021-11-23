using DomainNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{
    public interface IPetsitterRepository
    {
        Task<IEnumerable<Petsitter>> GetAsync();
        Task<Petsitter> GetAsync(long id);
        Task CreateAsync(Petsitter petsitter);
        Task<Petsitter> DeleteAsync(long id);
        Task<Petsitter> SetApplication(long id);
    }
}
