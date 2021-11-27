using DomainNew.Interfaces;
using DomainNew.Models;
using InfrastructureNew.EFDbContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfrastructureNew.Repositories
{
    class EFUserInfoRepository : IUserInfoRepository
    {
        private readonly EFMainDbContext context;

        public EFUserInfoRepository(EFMainDbContext context)
        {
            this.context = context;
        }
        public async Task CreateAsync(UserInfo userInfo)
        {
            context.InformationAboutUser.Add(userInfo);
            await context.SaveChangesAsync();
        }

        public async Task<UserInfo> DeleteAsync(long id)
        {
            UserInfo userInfo = await context.InformationAboutUser.FindAsync(id);

            if (userInfo != null)
            {
                context.Remove(userInfo);
                await context.SaveChangesAsync();
            }

            return userInfo;
        }

        public async Task<IEnumerable<UserInfo>> GetAsync()
        {
            return await context.InformationAboutUser.ToListAsync();
        }

        public async Task<UserInfo> GetAsync(long id)
        {
            return await context.InformationAboutUser.FindAsync(id);
        }
    }
}
