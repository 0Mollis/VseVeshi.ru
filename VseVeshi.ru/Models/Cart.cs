using Microsoft.AspNetCore.Identity;

namespace VseVeshi.ru.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public RentItems RentItems { get; set; }
        public IdentityUser User { get; set; }
        public int quantity { get; set; }
    }
}
