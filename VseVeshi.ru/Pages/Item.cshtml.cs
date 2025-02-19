using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Pages
{
    public class ItemModel : PageModel
    {
        public string SelectedItem { get; set; }

        private ApplicationDbContext _context;

        public ItemModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<RentItems> rentItems;
        public List<UsersDB> usersDB;

        public void OnGet(string Id)
        {
            SelectedItem = Id;
            rentItems = _context.RentItems.ToList();
            usersDB = _context.UsersDB.ToList();
        }
    }
}
