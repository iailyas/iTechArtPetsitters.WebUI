using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<MyUser> Get();
        MyUser Get(Guid id);
        void Create(MyUser _user);
        void Update(MyUser _user);
        MyUser Delete(Guid id);
    }
}
