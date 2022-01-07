using AutoMapper;
using Domain.Commands.PetCommand;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{

    public class PetService : IPetService
    {
        private readonly IPetRepository repository;
        private readonly IMapper mapper;
        public PetService(IPetRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<Pet>> GetAsync()
        {
            IEnumerable<Pet> Pets = await repository.GetAsync();
            if (Pets == null)
            {
                throw new Exception("Exception while accessing a Pet.");
            }
            return Pets;
        }

        public async Task<Pet> GetAsync(long id)
        {
            Pet pet = await repository.GetAsync(id);
            if (pet == null)
            {
                throw new Exception("Exception while while fetching Pet from the storage.");
            }
            return await repository.GetAsync(id);
        }
        public async Task<Pet> DeleteAsync(long id)
        {
            Pet pet = await repository.GetAsync(id);
            if (pet == null)
            {
                throw new Exception("Exception while using delete operation");
            }
            return await repository.DeleteAsync(id);
        }

        public async Task CreateAsync(AddPetCommand addPetCommand)
        {
            if (addPetCommand == null)
            {
                throw new Exception("Exception while creating a Pet.");
            }
            Pet pet = mapper.Map<Pet>(addPetCommand);
            await repository.CreateAsync(pet);
        }

        
    }
}
