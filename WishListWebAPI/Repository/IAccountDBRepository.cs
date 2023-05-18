
using Microsoft.AspNetCore.Identity;
using WishListWebAPI.DTO;
using WishListWebAPI.Model;

namespace WishListWebAPI.Repository
{
    public interface IAccountDBRepository
    {
        Task<IdentityResult> SignUpUserAsync(ApplicationUser user, string password);
        Task<SignInResult> SignInUserAsync(LoginDTO loginDTO);
        Task<ApplicationUser> FindUserByEmailAsync(string email);
        // IEnumerable<string> GetApplicationUserIds();
    }
}
