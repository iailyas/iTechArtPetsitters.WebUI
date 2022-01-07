
using AutoMapper;
using Domain.Commands.PetsittingJobCommand;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System;
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
            if (petsittingJob==null) 
            {
                throw new Exception("Exception while creating new PetsittingJob");
            }
            await repository.CreateAsync(petsittingJob);
        }

        public async Task<PetsittingJob> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<PetsittingJob>> GetAsync()
        {
            var petsittingJobs= await repository.GetAsync();
            if (petsittingJobs == null)
            {
                throw new Exception("Exception while accessing Petsitting job.");
            }
            return petsittingJobs;
        }

        public async Task<PetsittingJob> GetAsync(long id)
        {
            var petsittingJob= await GetAsync(id);
            if (petsittingJob == null)
            {
               throw new Exception("Exception while accessing a Petsitters's job");
            }
            return petsittingJob;
        }

        public async Task UpdateAsync(UpdatePetsittingJobCommand updatePetsittingJobCommand)
        {
            if (updatePetsittingJobCommand == null)
            {
                throw new Exception("Exeption while updating PetsittingJob");
            }
            PetsittingJob petsittingJob = mapper.Map<PetsittingJob>(updatePetsittingJobCommand);
           await repository.UpdateAsync(petsittingJob);
        }
    }
}
