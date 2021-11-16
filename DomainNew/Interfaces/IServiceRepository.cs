using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{

    //main operations for model(Service) 
    public interface IServiceRepository
    {
        IEnumerable<Service> Get();
        Task<Service> GetAsync(long id);
        Task CreateAsync(Service _service);
        Task UpdateAsunc(Service _service);
        Task<Service> DeleteAsync(long id);

    }

}
