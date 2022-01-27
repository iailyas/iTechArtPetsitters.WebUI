using AutoMapper;
using Domain.Models.Authentication;
using Domain.Service.Interfaces;
using Domain.Views.CurrentUserView;
using DomainNew.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace Domain.Service
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IUserRepository repository;
        private readonly IMapper mapper;

        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<ApplicationUser> userManager, IUserRepository repository, IMapper mapper)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.userManager = userManager;
            this.repository = repository;
            this.mapper = mapper;
        }

        public CurrentUserView GetCurrentUser()
        {
            var CurrentUserId = httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).ToString();
            CurrentUserView currentUserView = mapper.Map<CurrentUserView>(repository.GetAsync(long.Parse(CurrentUserId)));
            return currentUserView;
        }
        public long GetCurrentUserId()
        {

            string CurrentUserId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            long id = long.Parse(CurrentUserId);
            return id;
        }

    }
}
