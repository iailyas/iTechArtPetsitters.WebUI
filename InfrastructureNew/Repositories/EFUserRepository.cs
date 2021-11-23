﻿using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    // UNIT OF WORK

    //service
    //realization of repository with data from EFUserDBContext
    public class EFUserRepository : IUserService
    {
        private EFMainDbContext context; //_ or "c"
        //contructor
        public EFUserRepository(EFMainDbContext context)
        {
            this.context = context;
        }

        async Task<IEnumerable<User>> IUserService.GetAsync()
        {
            return await context.Users.ToListAsync();
        }

        async Task<User> IUserService.GetAsync(long id)
        {
            return await context.Users.FindAsync(id);
        }

        async Task IUserService.CreateAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
        }

        async Task IUserService.UpdateAsync(User user)
        {
            User currentUser = user;
            context.Update(currentUser);
            await context.SaveChangesAsync();
        }

        async Task<User> IUserService.DeleteAsync(long id)
        {
            User user = await context.Users.FindAsync(id);

            if (user != null)
            {
                context.Remove(user);
                await context.SaveChangesAsync();
            }

            return user;
        }



    }
}
