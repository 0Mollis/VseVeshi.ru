using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using VseVeshi.ru.Data;
using VseVeshi.ru.Models;

namespace VseVeshi.ru.Pages
{
    public class CatalogModel : PageModel
    {
        private ApplicationDbContext _context;

        public string SelectCategory;
        public string SearchQuery;
        public string SearchData;
        public string SearchPrice;
        public string SearchBrand;
        public string SearchColor;
        public string SearchGender;
        
        public CatalogModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<RentItems> rentItems;

        public void OnGet(string category)
        {
            SelectCategory = Request.Query["category"];
            SearchQuery = Request.Query["search"];
            SearchData = Request.Query["SearchData"];
            SearchPrice = Request.Query["SearchPrice"];
            SearchBrand = Request.Query["SearchBrand"];
            SearchColor = Request.Query["SearchColor"];
            SearchGender = Request.Query["SearchGender"];

            if (SelectCategory != null)
            {
                if (SearchQuery != null)
                {
                    rentItems = _context.RentItems.Where(x => x.catalogs == SelectCategory).Where(x => x.Name.Contains(SearchQuery)).ToList();
                }
                else { rentItems = _context.RentItems.Where(x => x.catalogs == SelectCategory).ToList(); }
            }
            else
            {
                if (SearchQuery != null)
                {
                    rentItems = _context.RentItems.Where(x => x.Name.Contains(SearchQuery)).ToList();
                }
                else { rentItems = _context.RentItems.ToList(); }
            }
        }
    }
}
