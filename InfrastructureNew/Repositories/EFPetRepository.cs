using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            return await Context.Pets.ToListAsync();
        }

        public async Task<Pet> GetAsync(long id)
        {
            return await Context.Pets.FindAsync(id);
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
            Context.ChangeTracker.AcceptAllChanges();
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



