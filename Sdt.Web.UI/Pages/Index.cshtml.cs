using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
        private readonly IHttpClientFactory _clientFactory;

        public IndexModel(ILogger<IndexModel> logger, IOptions<SdtAppSettings> sdtAppSettings, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
            SdtAppSettings = sdtAppSettings.Value;
        }

        public async Task OnGet()
        {
            try
            {
                using var client = _clientFactory.CreateClient("externalapiservice");

                var response = await client.GetStringAsync("sprueche/randomsdt");
                SdtVm = JsonSerializer.Deserialize<SpruchDesTagesViewModel>(response,new JsonSerializerOptions { PropertyNameCaseInsensitive = true});

            }
            catch (Exception ex)
            {
                _logger.LogError($"Fehler beim HttpClient: {ex.Message}");
            }
        }
    }
}
