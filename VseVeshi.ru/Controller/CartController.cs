using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private ApplicationDbContext _context;
        private UserManager<IdentityUser> _userManager;

        public CartController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost]

        public async Task<IActionResult> addToCart([FromBody] AddToCartViewModel model)
        {
            if(_userManager.GetUserId(User) != null)
            {
                var userId = _userManager.GetUserId(User);

                var item = new Cart();

                item.User = await _userManager.GetUserAsync(User);
                item.RentItems = _context.RentItems.Where(x =>  x.Id == model.itemId).FirstOrDefault();
                item.quantity = model.itemQuantity;
                _context.Add(item);
                _context.SaveChanges();
            }

            return Ok();
        }
    }
}
