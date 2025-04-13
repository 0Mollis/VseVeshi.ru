using Microsoft.AspNetCore.Identity;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Models
{
    public class OrderItems
    {
        public int Id { get; set; }
        public Orders Orders { get; set; }
        public RentItems RentItems { get; set; }
        public int Quantity { get; set; }
    }
}
