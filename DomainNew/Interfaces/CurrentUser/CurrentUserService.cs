using AutoMapper;
using Domain.Interfaces.CurrentUsers;
using DomainNew.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Domain.Interfaces.CurrentUser
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, IUserRepository repository,IMapper mapper)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.repository = repository;
            this.mapper = mapper;
        }

        public CurrentUserView GetCurrentUser()
        {
            var CurrentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            CurrentUserView currentUserView =mapper.Map<CurrentUserView>(repository.GetAsync(long.Parse(CurrentUserId)));
            return currentUserView;
        }

    }
}
