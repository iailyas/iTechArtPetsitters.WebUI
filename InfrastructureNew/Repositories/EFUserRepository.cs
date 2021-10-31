using Domain.Interfaces;
using Domain.Models;
using Infrastructure.EFDbContext;
using System;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private EFUserDBContext Context;
      
        IEnumerable<MyUser> IUserRepository.Get()
        {
            return Context.Users;
        }

        MyUser IUserRepository.Get(Guid id)
        {
            return Context.Users.Find(id);
        }

        void IUserRepository.Create(MyUser _user)
        {
            Context.Add<MyUser>(_user);
            Context.SaveChanges();
        }

        void IUserRepository.Update(MyUser _user)
        {
            MyUser currentUser = _user;
            

            Context.Update(currentUser);
            Context.SaveChanges();
        }

        MyUser IUserRepository.Delete(Guid id)
        {
            MyUser user =Context.Users.Find(id);

            if (user != null)
            {
                Context.Remove(user);
                Context.SaveChanges();
            }

            return user;
        }
       
       
       
    }
}
