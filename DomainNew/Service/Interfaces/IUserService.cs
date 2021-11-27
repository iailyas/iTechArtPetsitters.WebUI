using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAsync();
        Task<User> GetAsync(long id);
        Task CreateAsync(User _user);
        Task UpdateAsync(User _user);
        Task<User> DeleteAsync(long id);
        
    }
}
