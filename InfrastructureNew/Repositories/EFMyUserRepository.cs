using DomainNew.Interfaces;
using DomainNew.Models;
using Infrastructure.EFDbContext;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    //_ or "c" UNIT OF WORK
    //without _
    //service
    //realization of repository with data from EFUserDBContext
    public class EFMyUserRepository : IUserRepository
    {
        private EFMyUserDBContext Context; //_ or "c"
        //contructor
        public EFMyUserRepository(EFMyUserDBContext context)
        {
            Context = context;
        }

        IEnumerable<User> IUserRepository.Get()
        {
            return Context.Users.ToList();
        }

        User IUserRepository.Get(long id)
        {
            return Context.Users.Find(id);
        }

        void IUserRepository.Create(User _user) //without _
        {
            Context.Users.Add(_user);
            Context.SaveChanges();
        }

        void IUserRepository.Update(User _user)
        {
            User currentUser = _user;
            Context.Update(currentUser);
            Context.SaveChanges();
        }

        User IUserRepository.Delete(long id)
        {
            User user = Context.Users.Find(id);

            if (user != null)
            {
                Context.Remove(user);
                Context.SaveChanges();
            }

            return user;
        }



    }
}
