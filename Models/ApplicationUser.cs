using Microsoft.AspNetCore.Identity;

namespace StudentManagement.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Avatar { get; set; }
    }
}
