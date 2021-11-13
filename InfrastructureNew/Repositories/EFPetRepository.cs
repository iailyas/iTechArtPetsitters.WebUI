using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;

namespace InfrastructureNew.Repositories
{
    public class EFPetRepository : IPetRepository
    {
        private EFPetDBContext Context;

        public EFPetRepository(EFPetDBContext context)
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



