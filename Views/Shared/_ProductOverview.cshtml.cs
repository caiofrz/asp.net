using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace asp.net_mvc.Views.Shared
{
    public class _ProductOverview : PageModel
    {
        private readonly ILogger<_ProductOverview> _logger;

        public _ProductOverview(ILogger<_ProductOverview> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}