using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class addItemController : ControllerBase
    {
        private ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public addItemController(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpPost("addNewItem", Name = "addNewItem")]

        public async Task<IActionResult> addNewItem(RentItems data)
        {
            var userId = _userManager.GetUserId(User);
            data.userGiveId = userId;
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == userId);

            user.CountItem++;
            _context.RentItems.Add(data);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
