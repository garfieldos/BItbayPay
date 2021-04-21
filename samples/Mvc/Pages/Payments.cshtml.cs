using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BitBayPayClient;
using BitBayPayClient.Model;
using FluffySpoon.AspNet.NGrok;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Mvc.Pages
{
    public class Payments : PageModel
    {
        private readonly IBitBayPayService _bitBayPayService;
        private readonly INGrokHostedService _proxy;

        private readonly string BaseCurrency = "EUR";

        public Payments(IBitBayPayService bitBayPayService, INGrokHostedService proxy)
        {
            _bitBayPayService = bitBayPayService;
            _proxy = proxy;
        }

        public List<AvailableCurrency> AvailableCurrencies { get; set; }
        [BindProperty] public string? SelectedCurrency { get; set; }
        [BindProperty] public decimal SelectedValue { get; set; }

        public async Task<IActionResult> OnGet()
        {
            var availableCurrencies = await _bitBayPayService.GetAvailablePaymentCurrencyPairs(PaymentType.PAYMENT);
            if (availableCurrencies.Status == ResponseStatus.Fail)
                return RedirectToPage("Error", new
                {
                    ErrorMessage = availableCurrencies.Errors.Select(x => x.Reason)
                        .Aggregate((p, n) => $"{p},{n}")
                });
            var eurRelatedCurrencies = availableCurrencies.Data.Where(x =>
                x.SecondCurrency == BaseCurrency).ToList();
            AvailableCurrencies = eurRelatedCurrencies.ToList();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid) return Page();

            var orderId = Guid.NewGuid();
            var proxyUrl = "http://costam.pl";
            /*(await _proxy.GetTunnelsAsync())
                .First(x => x.Proto == "http")
                .PublicUrl;*/
            var payment = await _bitBayPayService.CreatePayment("USD", SelectedValue, orderId,
                SelectedCurrency,
                $"{proxyUrl}/success",
                $"{proxyUrl}/failure",
                $"{proxyUrl}/confirmation",
                CoveredBy.BUYER,
                true);
            if (payment.Status != ResponseStatus.OK)
                return RedirectToPage("Error", new
                {
                    ErrorMessage = payment.Errors.Select(x => x.Reason)
                        .Aggregate((p, n) => $"{p},{n}")
                });
            return Redirect(payment.Data.Url);
        }
    }
}