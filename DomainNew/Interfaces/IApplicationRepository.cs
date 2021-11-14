using DomainNew.Models;
using System.Collections.Generic;

namespace DomainNew.Interfaces
{
    public interface IApplicationRepository
    {
        IEnumerable<Application> Get();
        Application Get(long id);
        void Create(Application application);
        Application Delete(long id);
    }
}
