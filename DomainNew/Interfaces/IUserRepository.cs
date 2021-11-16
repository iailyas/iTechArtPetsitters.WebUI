using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{
    //main operations for model(MyUser) 
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        Task<User> GetAsync(long id);
        Task CreateAsync(User _user);
        Task UpdateAsync(User _user);
        Task<User> DeleteAsync(long id);
    }
}
