using DomainNew.Commands;
using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAsync();
        Task<User> GetAsync(long id);
        Task Register(UserUpdateCommand user);
        Task UpdateAsync(UserUpdateCommand user);
        Task<User> DeleteAsync(long id);
        
    }
}
