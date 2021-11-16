using DomainNew.Interfaces;
using DomainNew.Models;
using Infrastructure.EFDbContext;
using InfrastructureNew.EFDbContext;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    //_ or "c" UNIT OF WORK
    //without _
    //service
    //realization of repository with data from EFUserDBContext
    public class EFMyUserRepository : IUserRepository
    {
        private EFMainDbContext Context; //_ or "c"
        //contructor
        public EFMyUserRepository(EFMainDbContext context)
        {
            Context = context;
        }

        IEnumerable<User> IUserRepository.Get()
        {
            return Context.Users.ToList();
        }

        async Task<User> IUserRepository.GetAsync(long id)
        {
            return await Context.Users.FindAsync(id);
        }

        async Task IUserRepository.CreateAsync(User _user) //without _
        {
            await Context.Users.AddAsync(_user);
            await Context.SaveChangesAsync();
        }

        async Task IUserRepository.UpdateAsync(User _user)
        {
            User currentUser = _user;
            Context.Update(currentUser);
            await Context.SaveChangesAsync();
        }

        async Task<User> IUserRepository.DeleteAsync(long id)
        {
            User user =await Context.Users.FindAsync(id);

            if (user != null)
            {
                Context.Remove(user);
                await Context.SaveChangesAsync();
            }

            return user;
        }



    }
}
