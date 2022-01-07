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

            if (userInfo == null)
            {
                throw new Exception("Exception while creating a UserInfo.");
            }

            await repository.CreateAsync(userInfo);
        }

        public async Task<UserInfo> DeleteAsync(long id)
        {
            return await repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<UserInfo>> GetAsync()
        {
            var usersInfo = await repository.GetAsync();
            if (usersInfo == null)
            {
                throw new Exception("Exception while accessing UsersInfo.");
            }
            return usersInfo;
        }

        public async Task<UserInfo> GetAsync(long id)
        {
            var userInfo = await repository.GetAsync(id);
            if (userInfo == null)
            {
                throw new Exception("Exception while accessing UserInfo.");
            }
            return userInfo;
        }
    }
}
