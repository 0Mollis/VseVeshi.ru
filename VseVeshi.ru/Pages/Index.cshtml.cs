using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;
using VseVeshi.ru.Pages;

namespace VseVeshi.ru.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ApplicationDbContext context, ILogger<IndexModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public List<Catalog> catalog;

        private ApplicationDbContext _context;

        public void OnGet()
        {
            catalog = _context.Catalog.ToList();
        }
    }
}
