using Microsoft.AspNetCore.Identity;

namespace VseVeshi.ru.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public int CountItem { get; set; }
        public string DateOfRegistration { get; set; }
    }
}
