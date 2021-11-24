using DomainNew.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IUserInfoService
    {
        Task<IEnumerable<UserInfo>> GetAsync();
        Task<UserInfo> GetAsync(long id);
        Task CreateAsync(UserInfo userInfo);
        Task<UserInfo> DeleteAsync(long id);
    }
}
