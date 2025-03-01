using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
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
        public string SelectDate;
        public string SelectPrice;
        public string SelectBrand;
        public string SelectColor;
        public string SelectGender;
        
        public CatalogModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<RentItems> rentItems;

        public void OnGet(string category)
        {
            SelectCategory = Request.Query["category"];
            SearchQuery = Request.Query["search"];
            SelectDate = Request.Query["SelectDate"];
            SelectPrice = Request.Query["SelectPrice"];
            SelectBrand = Request.Query["SelectBrand"];
            SelectColor = Request.Query["SelectColor"];
            SelectGender = Request.Query["SelectGender"];

            if (SelectCategory != null)
            {
                if (SearchQuery != null)
                {

                    rentItems = _context.RentItems.Where(x => x.catalogs == SelectCategory).Where(x => x.Name.Contains(SearchQuery)).ToList();
                    CHECK(rentItems);
                }
                else { 
                    rentItems = _context.RentItems.Where(x => x.catalogs == SelectCategory).ToList();
                    CHECK(rentItems);
                }
            }
            else
            {
                if (SearchQuery != null)
                {
                    rentItems = _context.RentItems.Where(x => x.Name.Contains(SearchQuery)).ToList();
                    CHECK(rentItems);
                }
                else { 
                    rentItems = _context.RentItems.ToList();
                    CHECK(rentItems);
                }
            }
        }

        void CHECK(List<RentItems> forCheck)
        {
            if (SelectDate != "0") { forCheck = checkData(forCheck); }
            if (SelectPrice != "0") {checkPrice(forCheck); }
            if (SelectBrand != "0") { forCheck = checkBrand(forCheck); }
            if (SelectColor != "0") { forCheck = checkColor(forCheck); }
            if (SelectGender != "0") { forCheck = checkGender(forCheck); }
        }
        
        List<RentItems> checkData(List<RentItems> rentItemsL)
        {
            if (SelectDate == "1")
            {
                return rentItems = rentItemsL.Where(x => x.Days.Contains("3")).ToList();
            }
            else if(SelectDate == "2")
            {
                return rentItems = rentItemsL.Where(x => x.Days.Contains("7")).ToList();
            }
            else if(SelectDate == "3")
            {
                return rentItems = rentItemsL.Where(x => x.Days.Contains("14")).ToList();
            }
            else { return rentItemsL; }
        }
        void checkPrice(List<RentItems> rentItemsL)
        {
            if (SelectPrice == "1")
            {
                rentItemsL.Sort((x, y) => x.Price.CompareTo(y.Price));
            }
            else if(SelectPrice == "2")
            {
                rentItemsL.Sort((x, y) => y.Price.CompareTo(x.Price));
            }
        }
        List<RentItems> checkBrand(List<RentItems> rentItemsL)
        {
            if (SelectBrand == "1")
            {
                return rentItems = rentItemsL.Where(x => x.brand.Contains("High Peak")).ToList();
            }
            else if (SelectBrand == "2")
            {
                return rentItems = rentItemsL.Where(x => x.brand.Contains("Русь")).ToList();
            }
            else if (SelectBrand == "3")
            {
                return rentItems = rentItemsL;
            }
            else { return rentItemsL; }
        }
        List<RentItems> checkColor(List<RentItems> rentItemsL)
        {
            if (SelectColor == "1")
            {
                return rentItems = rentItemsL.Where(x => x.color.Contains("Красный")).ToList();
            }
            else if (SelectColor == "2")
            {
                return rentItems = rentItemsL.Where(x => x.color.Contains("Оранжевый")).ToList();
            }
            else if (SelectColor == "3")
            {
                return rentItems = rentItemsL.Where(x => x.color.Contains("Жёлтый")).ToList();
            }
            else if (SelectColor == "4")
            {
                return rentItems = rentItemsL.Where(x => x.color.Contains("Зелёный")).ToList();
            }
            else if (SelectColor == "5")
            {
                return rentItems = rentItemsL.Where(x => x.color.Contains("Голубоай")).ToList();
            }
            else if (SelectColor == "6")
            {
                return rentItems = rentItemsL.Where(x => x.color.Contains("Синий")).ToList();
            }
            else if (SelectColor == "7")
            {
                return rentItems = rentItemsL.Where(x => x.color.Contains("Фиолетовый")).ToList();
            }
            else { return rentItemsL; }
        }
        List<RentItems> checkGender(List<RentItems> rentItemsL)
        {
            if (SelectGender == "1")
            {
                return rentItems = rentItemsL.Where(x => x.gender.Contains("Мужской")).ToList();
            }
            else if (SelectGender == "2")
            {
                return rentItems = rentItemsL.Where(x => x.gender.Contains("Женский")).ToList();
            }
            else if (SelectGender == "3")
            {
                return rentItems = rentItemsL.Where(x => x.gender.Contains("Унисекс")).ToList();
            }
            else { return rentItemsL; }
        }
    }
}
