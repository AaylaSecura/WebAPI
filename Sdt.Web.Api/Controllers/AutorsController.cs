using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sdt.Data.Context;
using Sdt.Domain.Entities;

namespace Sdt.Web.Api.Controllers
{
    [Route("api/[controller]")]  //  localhost:12345/api/autors
    [ApiController]
    public class AutorsController : ControllerBase
    {
        #region Members/Constructors

        private readonly SdtDataContext _context;

        public AutorsController(SdtDataContext context)
        {
            _context = context;
        }

        #endregion

        #region GET

        [HttpGet]  // api/autors
        public ActionResult<List<Autor>> Get()
        {
            var autoren = _context.Autoren.ToList();

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
