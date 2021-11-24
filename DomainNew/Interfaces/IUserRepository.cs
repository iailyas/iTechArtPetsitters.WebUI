using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{
    //main operations for model(MyUser) 
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();
        Task<User> GetAsync(long id);
        Task CreateAsync(User user);
        Task UpdateAsync(User user);
        Task<User> DeleteAsync(long id);
        Task<PetsittingJob> ViewAllServices(long id);
    }
}
