using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly IMapper _mapper; //Automapper

        public AutorsController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region GET

        /// <summary>
        /// Gibt alle Autoren zurück
        /// </summary>
        /// <returns>Autoren</returns>
        [HttpGet]  // api/autors
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IEnumerable<AutorDTO>> Get()
        {
            var autoren = await _repository.Autor.GetAllAutorsAsync();
            // var autorenDto = autoren.Select(c => DtoFactory.CreateAutorDto(c)).ToList();
            var autorenDto = _mapper.Map<List<AutorDTO>>(autoren);

            return autorenDto;
        }

        /// <summary>
        /// Gibt den gesuchten Autor zurück
        /// </summary>
        /// <param name="id">Autor-Id</param>
        /// <returns>Autor</returns>
        [HttpGet("{id}")]  // api/autors/id => api/autors/1
        public async Task<IActionResult> Get(int id)
        {
            var autor = await _repository.Autor.GetAutorWithQuotesAsync(id);

            if (autor is null) return NotFound();

            return Ok(_mapper.Map<AutorDTO>(autor));
        }

        #endregion

        #region POST

        /// <summary>
        /// Erstellt einen neuen Autor
        /// </summary>
        /// <param name="autorDto">Autor-Dto</param>
        /// <returns>Neu erstellten Autor</returns>
        [HttpPost]
        public async Task<IActionResult> Post(AutorDTO autorDto)
        {
            //if (!ModelState.IsValid) return BadRequest(ModelState);

            var autor = _mapper.Map<Autor>(autorDto);

            if (TryValidateModel(autor))
            {
                _repository.Autor.Add(autor);
                await _repository.SaveAsync();

                var autorCreatedDto = _mapper.Map<AutorDTO>(autor);
                return CreatedAtAction(nameof(Get), new {id = autorCreatedDto.AutorId}, autorCreatedDto);
            }

            return BadRequest(ModelState);
        }

        [HttpPost("autorimage")]  //api/autors/autorimage
        [Consumes("multipart/form-data")]
        public async Task<ActionResult<AutorDTO>> PostWithImage([FromForm] AutorCreateDto autorCreateDto)
        {
            var autor = _mapper.Map<Autor>(autorCreateDto);

            if (TryValidateModel(autor))
            {
                _repository.Autor.Add(autor);
                await _repository.SaveAsync();

                var autorCreatedDto = _mapper.Map<AutorDTO>(autor);
                return CreatedAtAction(nameof(Get), new { id = autorCreatedDto.AutorId }, autorCreatedDto);
            }

            return BadRequest(ModelState);
        }

        #endregion
    }
}
