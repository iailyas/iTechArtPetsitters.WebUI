using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using System.Collections.Generic;
using System.Linq;

namespace InfrastructureNew.Repositories
{
    public class EFServiceRepository:IServiceRepository
    {
        
            private EFServiceDBContext Context;
            //contructor
            public EFServiceRepository(EFServiceDBContext context)
            {
                Context = context;
            }
            public IEnumerable<Service> Get()
            {
                return Context.Services.ToList();
            }

            public Service Get(long id)
            {
                return Context.Services.Find(id);
            }

            public void Create(Service _service)
            {
                Context.Services.Add(_service);
                Context.SaveChanges();
            }

            public void Update(Service _service)
            {
                Service currentService = _service;
                Context.Update(currentService);
                Context.SaveChanges();

            }

            public Service Delete(long id)
            {
                Service service = Context.Services.Find(id);

                if (service != null)
                {
                    Context.Remove(service);
                    Context.SaveChanges();
                }

                return service;
            }
        
    }
}
