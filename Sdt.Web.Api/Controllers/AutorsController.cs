using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sdt.Data.Context;
using Sdt.Data.Contracts;
using Sdt.Domain.Entities;
using Sdt.Web.Api.Dto;

namespace Sdt.Web.Api.Controllers
{
    [Route("api/[controller]")]  //  localhost:12345/api/autors
    [ApiController]
    public class AutorsController : ControllerBase
    {
        #region Members/Constructors

        private readonly IRepositoryWrapper _repository;

        public AutorsController(IRepositoryWrapper repository)
        {
            _repository = repository;
        }

        #endregion

        #region GET

        [HttpGet]  // api/autors
        public async Task<IEnumerable<AutorDTO>> Get()
        {
            var autoren = await _repository.Autor.GetAllAutorsAsync();
            var autorenDto = autoren.Select(c => DtoFactory.CreateAutorDto(c)).ToList();

            return autorenDto;
        } 
        
        [HttpGet("{id}")]  // api/autors/id => api/autors/1
        public async Task<IActionResult> Get(int id)
        {
            var autor = await _repository.Autor.GetAutorWithQuotesAsync(id);

            if (autor is null) return NotFound();

            return Ok(DtoFactory.CreateAutorDto(autor));
        }

        #endregion
    }
}
