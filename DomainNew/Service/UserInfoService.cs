using DomainNew.Interfaces;
using DomainNew.Models;
using DomainNew.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainNew.Service
{
    public class UserInfoService:IUserInfoService
    {
        private readonly IUserInfoRepository repository;

        public UserInfoService(IUserInfoRepository repository)
        {
            this.repository = repository;
        }

        public async Task CreateAsync(UserInfo userInfo)
        {
            await repository.CreateAsync(userInfo);
        }

        public async Task<UserInfo> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserInfo>> GetAsync()
        {
            return await repository.GetAsync();
        }

        public async Task<UserInfo> GetAsync(long id)
        {
            return await GetAsync(id);
        }
    }
}
