using AutoMapper;

namespace DomainNew.Commands
{
    public class UserUpdateCommand : Profile
    {
        public UserUpdateCommand
        {
         CreateMap<User, RegisterUserCommand>();
        }
}
}
