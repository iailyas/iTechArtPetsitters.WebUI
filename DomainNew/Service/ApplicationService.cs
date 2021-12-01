using AutoMapper;
using Domain.Commands.ApplicationCommand;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository repository;
        private readonly IMapper mapper;

        public ApplicationService(IApplicationRepository repository, IMapper autoMapper)
        {
            this.repository = repository;
            this.mapper = autoMapper;
        }

        public async Task CreateAsync(AddApplicationCommand addApplicationCommand)
        {
            
                Application application = mapper.Map<Application>(addApplicationCommand);
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
        public async Task SelectApplication(SelectApplicationCommand selectApplicationCommand)
        {
            Application application = mapper.Map<Application>(selectApplicationCommand);
            await repository.SelectApplication(application);
        }
    }
}
