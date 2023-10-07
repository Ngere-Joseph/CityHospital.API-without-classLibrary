using Microsoft.AspNetCore.Identity;

namespace CityInfo.API.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime JoinDate { get; set; } = DateTime.Now;
    }
}
