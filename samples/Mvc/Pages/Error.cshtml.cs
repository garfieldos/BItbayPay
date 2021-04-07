using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mvc.Pages
{
    public class Error : PageModel
    {
        public string ErrorMessage { get; set; }

        public void OnGet(string errorMessage)
        {
            ErrorMessage = errorMessage;
        }
    }
}