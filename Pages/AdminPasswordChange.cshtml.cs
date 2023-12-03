using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using TalkingStumpShop.Authentication;

namespace TalkingStumpShop.Pages
{
    [Authorize]
    public class AdminPasswordChangeModel : PageModel
    {
        private readonly AuthenticationContext _context;

        public AdminPasswordChangeModel(AuthenticationContext context)
        {
            _context = context;
        }

        [BindProperty]
        [Required]
        public string CurrentPassword { get; set; }

        [BindProperty]
        [Required]
        public string NewPassword { get; set; }

        [BindProperty]
        [Required]
        public string ConfirmPassword { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Stay on the same page and display validation errors
            }

            if (CurrentPassword != _context.Users.First().Password)
            {
                ModelState.AddModelError(string.Empty, "Неверно введен текущий пароль");
                return Page();
            }

            if (NewPassword != ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "Новый пароль не совпадает с подтверждением");
                return Page();
            }

            var admin = _context.Users.First(x => x.Login == "admin");

            admin.Password = NewPassword;
            _context.Users.Update(admin);
            _context.SaveChanges();

            return RedirectToPage("/AdminProducts");
        }
    }
}
