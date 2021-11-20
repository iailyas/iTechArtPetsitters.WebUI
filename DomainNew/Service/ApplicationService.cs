using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class ApplicationService : Interfaces.IApplicationService
    {
        private readonly DomainNew.Interfaces.IApplicationService repository;

        public ApplicationService(DomainNew.Interfaces.IApplicationService repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(Application application)
        {
            await repository.CreateAsync(application);
        }

        public async Task<Application> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Application>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<Application> GetAsync(long id)
        {
            return await repository.GetAsync(id);
        }
    }
}
