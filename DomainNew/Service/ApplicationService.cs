using AutoMapper;
using Domain.Commands.ApplicationCommand;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System;
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
            if (addApplicationCommand == null)
            {
                throw new Exception("Exception while creating new Application");
            }
            Application application = mapper.Map<Application>(addApplicationCommand);

            await repository.CreateAsync(application);
        }

        public async Task<Application> DeleteAsync(long id)
        {
            Application application = await repository.DeleteAsync(id);
            if (application == null)
            {
                throw new Exception("Exception while delete Application by id from the storage.");
            }
            return application;
        }

        public async Task<IEnumerable<Application>> GetAsync()
        {
            IEnumerable<Application> applications = await repository.GetAsync();
            if (applications == null)
            {
                throw new AccessViolationException("Violation Exception while accessing the resource.");
            }

            return applications;
        }

        public async Task<Application> GetAsync(long id)
        {
            Application application = await repository.GetAsync(id);
            if (application == null)
            {
                throw new Exception("Exception while fetching all Applications from the storage.");
            }
            return application;
        }
        public async Task SelectApplication(SelectApplicationCommand selectApplicationCommand)
        {
            if (selectApplicationCommand == null)
            {
                throw new Exception("Exception while selection Application by id from the storage.");
            }
            Application application = mapper.Map<Application>(selectApplicationCommand);
            await repository.SelectApplication(application);
        }
    }
}
