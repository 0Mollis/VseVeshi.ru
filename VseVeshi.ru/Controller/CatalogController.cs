using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;
using VseVeshi.ru.Pages;

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

        public List<RentItems> Get(string category, string query = "")
        {
            return _context.RentItems.Where(x => x.Name.Contains(query)).ToList();
        }
        
    }
}
