using Domain.Service;

namespace Domain.Commands.UserInfoCommand
{
    public class AddUserInfoCommand
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}
