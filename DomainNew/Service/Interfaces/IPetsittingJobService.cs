using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IPetsittingJobService
    {
        Task<IEnumerable<PetsittingJob>> GetAsync();
        Task<PetsittingJob> GetAsync(long id);
        Task CreateAsync(PetsittingJob service);
        Task UpdateAsunc(PetsittingJob service);
        Task<PetsittingJob> DeleteAsync(long id);
    }
}
