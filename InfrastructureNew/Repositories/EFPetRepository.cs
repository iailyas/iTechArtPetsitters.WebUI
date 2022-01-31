using DomainNew.Interfaces;
using DomainNew.Service;
using InfrastructureNew.EFDbContext;
using System.Threading.Tasks;
using DomainNew.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;


namespace InfrastructureNew.Repositories
{
    public class EFPetRepository : IPetRepository
    {
        private EFMainDbContext Context;
        
        public EFPetRepository(EFMainDbContext context)
        {
            Context = context;
        }

        public async Task<IEnumerable<Pet>> GetAsync()
        {
            return await Context.Pets.AsNoTracking().ToListAsync();
        }

        public async Task<Pet> GetAsync(long id)
        {
            return await Context.Pets.AsNoTracking().SingleAsync(b => b.Id == id);
        }
        public async Task CreateAsync(Pet pet)
        {
            await Context.AddAsync(pet);
            await Context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Pet pet)
        {
            
            
            Pet currentPet = pet;
            Context.Update(currentPet);
            await Context.SaveChangesAsync();
        }

        public async Task<Pet> DeleteAsync(long id)
        {
            Pet pet = await Context.Pets.FindAsync(id);

            if (pet != null)
            {
                Context.Remove(pet);
                await Context.SaveChangesAsync();
            }

            return pet;

        }

        

       
    }
}



