using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GroceryList2.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public bool IsMobile { get; set;}
        public void OnGet()
        {
            var userAgent = Request.Headers["User-Agent"];
            IsMobile = userAgent.ToString().Contains("mobile", StringComparison.OrdinalIgnoreCase);
        }
    }
}
