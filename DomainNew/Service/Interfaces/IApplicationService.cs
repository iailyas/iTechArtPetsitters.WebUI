using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IApplicationService
    {
        Task<IEnumerable<Application>> GetAsync();
        Task<Application> GetAsync(long id);
        Task CreateAsync(AddApplicationCommand addApplicationCommand);
        Task<Application> DeleteAsync(long id);
        Task SelectApplication(AddApplicationCommand addApplicationCommand);
    }
}
