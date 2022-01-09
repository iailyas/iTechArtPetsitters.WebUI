using Domain.Interfaces.CurrentUsers;

namespace Domain.Interfaces
{
    public interface ICurrentUserService
    {
        CurrentUserView GetCurrentUser();
    }
}
