using DomainNew.Models;
using System.Collections.Generic;

namespace DomainNew.Interfaces
{
    //main operations for model(MyUser) 
    public interface IUserRepository
    {
        IEnumerable<MyUser> Get();
        MyUser Get(long id);
        void Create(MyUser _user);
        void Update(MyUser _user);
        MyUser Delete(long id);
    }
}
