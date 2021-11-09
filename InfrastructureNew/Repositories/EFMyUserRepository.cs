using Domain.Interfaces;
using Domain.Models;
using Infrastructure.EFDbContext;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.Repositories
{
    //realization of repository with data from EFUserDBContext
    public class EFMyUserRepository : IUserRepository
    {
        private EFMyUserDBContext Context;
        //contructor
        public EFMyUserRepository(EFMyUserDBContext context)
        {
            Context = context;
        }

        IEnumerable<MyUser> IUserRepository.Get()
        {
            return Context.Users.ToList();
        }

        MyUser IUserRepository.Get(long id)
        {
            return Context.Users.Find(id);
        }

        void IUserRepository.Create(MyUser _user)
        {
            Context.Users.Add(_user);
            Context.SaveChanges();
        }

        void IUserRepository.Update(MyUser _user)
        {
            MyUser currentUser = _user;
            Context.Update(currentUser);
            Context.SaveChanges();
        }

        MyUser IUserRepository.Delete(long id)
        {
            MyUser user = Context.Users.Find(id);

            if (user != null)
            {
                Context.Remove(user);
                Context.SaveChanges();
            }

            return user;
        }



    }
}
