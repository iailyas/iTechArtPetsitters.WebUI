using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{
    public interface IApplicationRepository
    {
        IEnumerable<Application> Get();
        Task<Application> GetAsync(long id);
        Task CreateAsync(Application application);
        Task<Application> DeleteAsync(long id);
    }
}
