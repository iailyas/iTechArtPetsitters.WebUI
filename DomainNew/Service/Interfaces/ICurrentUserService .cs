

using Domain.Views.CurrentUserView;
using System.Threading.Tasks;

namespace Domain.Service.Interfaces
{
    public interface ICurrentUserService
    {
        public CurrentUserView GetCurrentUser();
        public long GetCurrentUserId();
    }
}
