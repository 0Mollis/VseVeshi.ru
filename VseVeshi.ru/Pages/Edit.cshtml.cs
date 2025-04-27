using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Pages
{
    [Authorize(Roles = "admin")]
    public class EditModel : PageModel
    {
        private readonly VseVeshi.ru.Data.ApplicationDbContext _context;

        public EditModel(VseVeshi.ru.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RentItems RentItems { get; set; } = default!;
        public List<RentItems> rentItems;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            rentItems = _context.RentItems.ToList();
            if (id == null)
            {
                return Page();
            }

            var rentitems =  await _context.RentItems.FirstOrDefaultAsync(m => m.Id == id);
            if (rentitems == null)
            {
                return NotFound();
            }
            RentItems = rentitems;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(RentItems).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentItemsExists(RentItems.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect(Url.Page("./Edit", new { id = id }));
        }

        private bool RentItemsExists(int id)
        {
            return _context.RentItems.Any(e => e.Id == id);
        }
    }
}
