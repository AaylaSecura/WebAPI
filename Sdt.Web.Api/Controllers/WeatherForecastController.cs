using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sdt.Web.Api.Controllers
{
    public interface IBier
    {
        string GibBier();
    }

    public class Union : IBier
    {
        public string GibBier()
        {
            return "Union";
        }
    } 
    
    public class Veltins : IBier
    {
        public string GibBier()
        {
            return "Veltins";
        }
    }


    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBier _bier;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IBier bier)
        {
            _logger = logger;
            _bier = bier;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bier.GibBier());
        }
    }
}
