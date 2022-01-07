using AutoMapper;
using Domain.Commands.PetsitterCommand;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class PetsitterService : IPetsitterService
    {
        private readonly IPetsitterRepository repository;
        private readonly IMapper mapper;

        public PetsitterService(IPetsitterRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task CreateAsync(AddPetsitterCommand addPetsitterCommand)
        {
            Petsitter petsitter = mapper.Map<Petsitter>(addPetsitterCommand);
            if (petsitter==null) 
            {
                throw new Exception("Exception while creating new Petsitter");
            }
            await repository.CreateAsync(petsitter);
        }

        public async Task<Petsitter> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Petsitter>> GetAsync()
        {
            var Petsitters = await repository.GetAsync();
            if (Petsitters==null) 
            {
                throw new Exception("Exception while accessing Petsitters");
            }
            return Petsitters;
        }

        public async Task<Petsitter> GetAsync(long id)
        {
            var petsitter = await repository.GetAsync(id);
            if (petsitter == null)
            {
                throw new Exception("Exception while while fetching Pet from the storage.");
            }
            return petsitter;
        }

        public Task<Petsitter> SetApplication(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
