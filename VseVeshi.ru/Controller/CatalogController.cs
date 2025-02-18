using Microsoft.AspNetCore.Mvc;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class CatalogController : ControllerBase
    {
        private ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public List<RentItems> Get()
        {
            return _context.RentItems.ToList();
        }
    }
}
