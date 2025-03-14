using Microsoft.AspNetCore.Mvc;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class addItemController : ControllerBase
    {
        private ApplicationDbContext _context;

        public addItemController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("addNewItem", Name = "addNewItem")]

        public async Task<IActionResult> addNewItem(RentItems data)
        {
            _context.RentItems.Add(data);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
