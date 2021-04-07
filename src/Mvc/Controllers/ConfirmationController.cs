using System.Threading.Tasks;
using BitBayPayClient.Model;
using Microsoft.AspNetCore.Mvc;

namespace Mvc.Controllers
{
    public class ConfirmationController : Controller
    {
        [HttpPost]
        [Route("confirmation")]
        public async Task<IActionResult> Confirm([FromBody] PaymentStatusChange paymentStatus)
        {
            // process response here

            return this.Ok();
        }
    }
}