using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Interfaces
{
    public interface IUserInfoRepository
    {
        Task<IEnumerable<UserInfo>> GetAsync();
        Task<UserInfo> GetAsync(long id);
        Task CreateAsync(UserInfo userInfo);
        Task<UserInfo> DeleteAsync(long id);
    }
}
