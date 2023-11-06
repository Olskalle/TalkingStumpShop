using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using TalkingStumpShop.Authentication;
using TalkingStumpShop.Authentication.Models;

using AuthModel = TalkingStumpShop.Authentication.Models.LoginModel;

namespace TalkingStumpShop.Pages
{
    public class LoginModel : PageModel
    {
        private readonly AuthenticationContext _context;

        public LoginModel(AuthenticationContext context)
        {
            _context = context;
            _context.Users.Add(new User
            {
                Login = "admin",
                Password = "123345"
            });
            _context.SaveChanges();
        }

        [BindProperty]
        public AuthModel? Credentials { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (Credentials is null) return BadRequest();

            User? user = _context.Users.FirstOrDefault(u => Credentials.Login == Credentials.Login && u.Password == Credentials.Password);
            if (user != null)
            {
                await Authenticate(Credentials.Login); // аутентификация

                return RedirectToPage("/Index");
            }
            ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            return Page();
        }
        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
