using DomainNew.Models;
using System.Collections.Generic;

namespace DomainNew.Interfaces
{
    //main operations for model(MyUser) 
    public interface IUserRepository
    {
        IEnumerable<User> Get();
        User Get(long id);
        void Create(User _user);
        void Update(User _user);
        User Delete(long id);
    }
}
