using DomainNew.Models;
using System.Collections.Generic;

namespace DomainNew.Interfaces
{

    //main operations for model(Service) 
    public interface IServiceRepository
    {
        IEnumerable<Service> Get();
        Service Get(long id);
        void Create(Service _service);
        void Update(Service _service);
        Service Delete(long id);
    }

}
