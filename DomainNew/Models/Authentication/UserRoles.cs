using Microsoft.AspNetCore.Identity;

namespace Domain.Models.Authentication
{
    public class UserRoles: IdentityRole<long>
    {
        public const string Admin = "Administrator";
        public const string User = "User";
        public const string Petsitter = "Petsitter";
    }
}
