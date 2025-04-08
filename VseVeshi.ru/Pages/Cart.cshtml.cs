using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Pages
{
    public class CartModel : PageModel
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public CartModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public List<Cart> carts;

        public void OnGet()
        {
            carts = _context.carts.Include(c => c.RentItems).Include(c => c.User).Where(x => x.User != null && x.User.Id == _userManager.GetUserId(User)).ToList();
        }
    }
}
