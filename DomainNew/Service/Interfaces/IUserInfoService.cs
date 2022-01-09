using Domain.Commands.UserInfoCommand;
using DomainNew.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DomainNew.Service.Interfaces
{
    public interface IUserInfoService
    {
        Task<IEnumerable<UserInfo>> GetAsync();
        Task<UserInfo> GetAsync(long id);
        Task CreateAsync(AddUserInfoCommand addUserInfoCommand);
        Task<UserInfo> DeleteAsync(long id);
    }
}
