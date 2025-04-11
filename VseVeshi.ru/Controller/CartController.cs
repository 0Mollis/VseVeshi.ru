using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
            if (_userManager.GetUserId(User) != null)
            {
                var userId = _userManager.GetUserId(User);

                var item = _context.carts.Where(x => x.User.Id == userId && x.RentItems.Id == model.itemId).FirstOrDefault();

                if (item == null)
                {
                    item = new Cart();

                    item.User = await _userManager.GetUserAsync(User);
                    item.RentItems = _context.RentItems.Where(x => x.Id == model.itemId).FirstOrDefault();
                    item.quantity = model.itemQuantity;
                    _context.Add(item);
                    _context.SaveChanges();
                    return Ok();
                }
                var a = _context.RentItems.Where(x => x.Id == model.itemId).FirstOrDefault();
                if (item.quantity < a.quantity)
                {
                    item.quantity++;
                    _context.carts.Update(item);
                    _context.SaveChanges();
                }
            }
            return Ok();
        }

        [HttpGet]

        public List<Cart> GetCart() {
            var userId = _userManager.GetUserId(User);
            if (userId != null)
            {
                return _context.carts.Include(x => x.RentItems).Include(x => x.User).Where(x => x.User.Id == userId).ToList();
            }
            return null;
        }

        [HttpPost("remove", Name = "remove")]

        public async Task<IActionResult> Remove([FromBody] RemoveOrQuantity model)
        {
            var userId = _userManager.GetUserId(User);
            var item = _context.carts.Where(x => x.User.Id == userId && x.RentItems.Id == model.itemId).FirstOrDefault();

            if (item == null) {
                return BadRequest();
            }

            if (model.removeBool == 1) _context.carts.Remove(item);
            else if (item.quantity > 1) {
                item.quantity--;
                _context.carts.Update(item);
            }
            _context.SaveChanges();
            return Ok();
        }
    }
}
