using AutoMapper;
using Domain.Service.Interfaces;
using Domain.Views.CurrentUserView;
using DomainNew.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Domain.Service
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
            var CurrentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).ToString();
            CurrentUserView currentUserView =mapper.Map<CurrentUserView>(repository.GetAsync(long.Parse(CurrentUserId)));
            return currentUserView;
        }
        public long GetCurrentUserId()
        {            
            string CurrentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).ToString();
            long id = long.Parse(CurrentUserId);
            return id;
        }

    }
}
