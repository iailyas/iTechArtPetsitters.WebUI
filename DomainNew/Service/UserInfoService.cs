using AutoMapper;
using Domain.Commands.UserInfoCommand;
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
        private readonly IMapper mapper;

        public UserInfoService(IUserInfoRepository repository,IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task CreateAsync(AddUserInfoCommand addUserInfoCommand)
        {
            UserInfo userInfo = mapper.Map<UserInfo>(addUserInfoCommand);
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
