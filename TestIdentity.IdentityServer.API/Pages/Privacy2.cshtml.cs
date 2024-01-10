using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestIdentity.IdentityServer.API.Pages
{
    [Authorize(Policy = "ManageCustomers")]
    public class PrivacyModel2 : PageModel
    {
        public void OnGet()
        {
        }
    }

}
