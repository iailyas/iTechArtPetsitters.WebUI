
using AutoMapper;
using Domain.Commands.PetsittingJobCommand;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{

    public class PetsittingJobService : IPetsittingJobService
    {
        private readonly IPetsittingJobRepository repository;
        private readonly IMapper mapper;

        public PetsittingJobService(IPetsittingJobRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task CreateAsync(AddPetsittingJobCommand addPetsittingJobCommand)
        {
            PetsittingJob petsittingJob = mapper.Map<PetsittingJob>(addPetsittingJobCommand);
            await repository.CreateAsync(petsittingJob);
        }

        public async Task<PetsittingJob> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PetsittingJob>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<PetsittingJob> GetAsync(long id)
        {
            return await GetAsync(id);
        }

        public async Task UpdateAsunc(UpdatePetsittingJobCommand updatePetsittingJobCommand)
        {
           PetsittingJob petsittingJob = mapper.Map<PetsittingJob>(updatePetsittingJobCommand);
           await repository.UpdateAsync(petsittingJob);
        }
    }
}
