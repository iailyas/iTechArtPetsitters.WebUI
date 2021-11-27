using AutoMapper;
using DomainNew.Interfaces;
using DomainNew.Service.Interfaces;

namespace DomainNew.Commands
{
    public class UserUpdateCommand
    {
        public IUserService Configure(IUserRepository repository)
        {

            // 
            var config = new MapperConfiguration(cfg => cfg.CreateMap<IUserRepository, IUserService>());
            // 
            var mapper = new Mapper(config);
            // 
            var user = mapper.Map<IUserService>(repository.GetAsync());
            return user;
        }
    }
}
