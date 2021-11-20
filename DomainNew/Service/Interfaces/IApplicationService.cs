using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    interface IApplicationService
    {
        Task<IEnumerable<Application>> GetAsync();
        Task<Application> GetAsync(long id);
        Task CreateAsync(Application application);
        Task<Application> DeleteAsync(long id);
    }
}
