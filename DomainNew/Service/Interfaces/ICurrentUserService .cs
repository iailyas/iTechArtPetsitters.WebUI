

using Domain.Views.CurrentUserView;

namespace Domain.Service.Interfaces
{
    public interface ICurrentUserService
    {
        public CurrentUserView GetCurrentUser();
    }
}
