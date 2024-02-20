using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using System.Globalization;

namespace FRS.Pages
{


    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IConfiguration _configuration;

        public IndexModel(ILogger<IndexModel> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public void OnGet()
        {
            string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            ViewData["TimeStamp"] = dateTime;
        }

    }
}