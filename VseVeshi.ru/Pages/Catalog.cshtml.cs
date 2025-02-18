using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Pages
{
    public class CatalogModel : PageModel
    {
        public string SelectedCategory { get; set; }

        private ApplicationDbContext _context;
        public CatalogModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<RentItems> rentItems;

        public void OnGet(string category)
        {
            SelectedCategory = category; 
            rentItems = _context.RentItems.ToList();
        }
    }
}
