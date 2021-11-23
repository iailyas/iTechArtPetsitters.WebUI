using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class UserService : Interfaces.IUserService
    {
        private readonly DomainNew.Interfaces.IUserService repository;

        public UserService(DomainNew.Interfaces.IUserService repostory)
        {
            this.repository = repostory;
        }

        public async Task CreateAsync(User user)
        {
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

        public async Task UpdateAsync(User user)
        {
            await repository.UpdateAsync(user);
        }
    }
}
