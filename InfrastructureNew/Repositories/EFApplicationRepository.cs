using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using System.Collections.Generic;
using System.Linq;

namespace InfrastructureNew.Repositories
{
    public class EFApplicationRepository : IApplicationRepository
    {
        private EFApplicationDBContext context;

        public EFApplicationRepository(EFApplicationDBContext context)
        {
            this.context = context;
        }
        public void Create(Application application)
        {
            context.Applications.Add(application);
            context.SaveChanges();
        }

        public Application Delete(long id)
        {
            Application application = context.Applications.Find(id);

            if (application != null)
            {
                context.Remove(application);
                context.SaveChanges();
            }

            return application;
        }

        public IEnumerable<Application> Get()
        {
            return context.Applications.ToList();
        }

        public Application Get(long id)
        {
            return context.Applications.Find(id);
        }
    }
}
