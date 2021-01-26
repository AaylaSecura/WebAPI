using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sdt.Domain.Entities;

namespace Sdt.Web.Api.Controllers
{
    [Route("api/[controller]")]  //  localhost:12345/api/autors
    [ApiController]
    public class AutorsController : ControllerBase
    {
        #region Members/Constructors

        public AutorsController()
        {
            
        }

        #endregion

        #region GET

        [HttpGet]  // api/autors
        public ActionResult<List<Autor>> Get()
        {
            var autoren = new List<Autor> {new Autor {Name = "Ali"}, new Autor { Name = "Du" } };

            return autoren;
        } 
        
        [HttpGet("{id}")]  // api/autors/id => api/autors/1
        public IActionResult Get(int id)
        {
            return Ok("Hallo Id");
        }

        #endregion
    }
}
