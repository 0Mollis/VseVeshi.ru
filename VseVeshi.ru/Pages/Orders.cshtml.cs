using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Pages
{
    public class OrdersModel : PageModel
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public OrdersModel(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Orders> orders;

        public void OnGet()
        {
            orders = _context.Orders.Include(x => x.User).ToList();
        }
    }
}
