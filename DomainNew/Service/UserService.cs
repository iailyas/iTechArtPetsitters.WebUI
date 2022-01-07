using AutoMapper;
using Domain.Commands.UserCommand;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        public UserService(IUserRepository repostory,IMapper autoMapper)
        {
            this.repository = repostory;
            this.mapper = autoMapper;

        }

        public async Task Register(RegisterUserCommand registerUserCommand)
        {
            User user = mapper.Map<User>(registerUserCommand);
            await repository.CreateAsync(user);
        }

        public async Task<User> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            var users = await repository.GetAsync();
            if (users == null)
            {
                throw new Exception("Exception while accessing Users.");
            }
            return users;
        }

        public async Task<User> GetAsync(long id)
        {
            var user = await repository.GetAsync(id);
            if (user == null)
            {
                throw new Exception("Exception while accessing User.");
            }
            return user;
        }

        public async Task UpdateAsync(UpdateUserCommand updateUserCommand)
        {
            User user = mapper.Map<User>(updateUserCommand);
            if (user==null) 
            {
                throw new Exception("Exception while updating User");
            }
            await repository.UpdateAsync(user);
        }
    }
}
