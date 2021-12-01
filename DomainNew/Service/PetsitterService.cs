using AutoMapper;
using Domain.Commands.PetsitterCommand;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
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
            await repository.CreateAsync(petsitter);
        }

        public async Task<Petsitter> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Petsitter>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<Petsitter> GetAsync(long id)
        {
            return await repository.GetAsync(id);
        }

        public Task<Petsitter> SetApplication(long id)
        {
            throw new System.NotImplementedException();
        }
    }
}
