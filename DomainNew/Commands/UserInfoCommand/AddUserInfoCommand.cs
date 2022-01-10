using Domain.Service;

namespace Domain.Commands.UserInfoCommand
{
    public class AddUserInfoCommand
    {
        public CurrentUserService currentUserService;
        public long Id => currentUserService.GetCurrentUser().Id;
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
