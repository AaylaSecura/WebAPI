using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Sdt.Web.UI.Model;

namespace Sdt.Web.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public SpruchDesTagesViewModel SdtVm { get; set; }
        public SdtAppSettings SdtAppSettings { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IOptions<SdtAppSettings> sdtAppSettings)
        {
            _logger = logger;
            SdtAppSettings = sdtAppSettings.Value;
        }

        public void OnGet()
        {
            //TODO: Daten holen von webapi
        }
    }
}
