using AutoMapper;
using Domain.Commands.User;
using DomainNew.Commands;
using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
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
            return await repository.GetAsync();
        }

        public async Task<User> GetAsync(long id)
        {
            return await repository.GetAsync(id);
        }

        public async Task UpdateAsync(UpdateUserCommand updateUserCommand)
        {
            User user = mapper.Map<User>(updateUserCommand);
            await repository.UpdateAsync(user);
        }
    }
}
