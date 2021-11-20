using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    interface IPetsittingService
    {
        Task<IEnumerable<PetsittingService>> GetAsync();
        Task<PetsittingService> GetAsync(long id);
        Task CreateAsync(PetsittingService _service);
        Task UpdateAsunc(PetsittingService _service);
        Task<PetsittingService> DeleteAsync(long id);
    }
}
