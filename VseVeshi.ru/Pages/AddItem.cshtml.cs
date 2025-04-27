using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VseVeshi.ru.Pages
{
    [Authorize]
    public class AddItemModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
