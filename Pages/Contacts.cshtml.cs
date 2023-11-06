using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TalkingStumpShop.Pages
{
    [Authorize]
    public class ContactsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
