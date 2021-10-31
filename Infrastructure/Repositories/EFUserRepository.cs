using Domain.Interfaces;
using Domain.Models;
using Infrastructure.EFDbContext;
using System;


namespace Infrastructure.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        private EFUserDBContext Context;
        //public IEnumerable<Users> Get()
        //{
        //    return Context.Users;
        //}
        public MyUser Get(Guid Id)
        {
            return Context.Users.Find(Id);
        }
        public EFUserRepository(EFUserDBContext context)
        {
            Context = context;
        }
        public void Create(MyUser user)
        {
            Context.Users.Add(user);
            Context.SaveChanges();
        }
        public void Update(MyUser updatedUser)
        {
            MyUser currentUser = Get(updatedUser.id);
           

            Context.Users.Update(currentUser);
            Context.SaveChanges();
        }

        public MyUser Delete(Guid Id)
        {
            MyUser user = Get(Id);

            if (user.id !=null )
            {
                Context.Users.Remove(user);
                Context.SaveChanges();
            }

            return user;
        }
    }
}
