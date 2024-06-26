using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace asp.net_mvc.Views.Order
{
    public class CompletedCheckout : PageModel
    {
        private readonly ILogger<CompletedCheckout> _logger;

        public CompletedCheckout(ILogger<CompletedCheckout> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}