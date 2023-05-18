using Microsoft.AspNetCore.Identity;

namespace WishListWebAPI.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
