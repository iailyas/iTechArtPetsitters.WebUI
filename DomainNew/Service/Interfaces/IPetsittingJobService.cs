using Domain.Commands.PetsittingJobCommand;
using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IPetsittingJobService
    {
        Task<IEnumerable<PetsittingJob>> GetAsync();
        Task<PetsittingJob> GetAsync(long id);
        Task CreateAsync(AddPetsittingJobCommand addPetsittingJobCommand);
        Task UpdateAsunc(UpdatePetsittingJobCommand addPetsittingJobCommand);
        Task<PetsittingJob> DeleteAsync(long id);
    }
}
