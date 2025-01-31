using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Models
{
    public class Users :IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

    }
}
