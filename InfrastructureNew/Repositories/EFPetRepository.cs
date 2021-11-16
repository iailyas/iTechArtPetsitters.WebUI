using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;

namespace InfrastructureNew.Repositories
{
    public class EFPetRepository : IPetRepository
    {
        private EFMainDbContext Context;

        public EFPetRepository(EFMainDbContext context)
        {
            Context = context;
        }

        public void Create(Pet pet)
        {
            Context.Add(pet);
            Context.SaveChanges();
        }

        public Pet Delete(long id)
        {
            Pet pet = Context.Pets.Find(id);

            if (pet != null)
            {
                Context.Remove(pet);
                Context.SaveChanges();
            }

            return pet;

        }
    }
}



