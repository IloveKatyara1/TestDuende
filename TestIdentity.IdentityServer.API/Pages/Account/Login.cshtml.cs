using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace TestIdentity.IdentityServer.API.Pages.Account
{
    public class Login : PageModel
    {
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ReturnUrl { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() 
        {
            if (!(String.IsNullOrWhiteSpace(Username) && String.IsNullOrWhiteSpace(Password)))
            {
                var claims = new List<Claim>
                {
                    new ("sub", "123"),
                    new ("name", "John"),
                    new ("role", "admin")
                };

                var ci = new ClaimsIdentity(claims, "pwd", "name", "role");
                var cp = new ClaimsPrincipal(ci);

                await HttpContext.SignInAsync(cp);

                return LocalRedirect(ReturnUrl);
            }

            return Page();
        }
    }
}
