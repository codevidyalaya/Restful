using Microsoft.AspNetCore.Identity;

namespace Restful_API.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
    }
}
