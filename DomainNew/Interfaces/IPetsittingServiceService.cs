using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{

    //main operations for model(Service) 
    public interface IPetsittingServiceService
    {
        Task<IEnumerable<PetsittingService>> GetAsync();
        Task<PetsittingService> GetAsync(long id);
        Task CreateAsync(PetsittingService _service);
        Task UpdateAsunc(PetsittingService _service);
        Task<PetsittingService> DeleteAsync(long id);
    }

}
