using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{

    //main operations for model(Service) 
    public interface IPetsittingService
    {
        Task<IEnumerable<PetsittingJob>> GetAsync();
        Task<PetsittingJob> GetAsync(long id);
        Task CreateAsync(PetsittingJob _service);
        Task UpdateAsunc(PetsittingJob _service);
        Task<PetsittingJob> DeleteAsync(long id);
    }

}
