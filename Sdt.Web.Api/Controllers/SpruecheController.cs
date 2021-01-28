using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Sdt.Data.Contracts;
using Sdt.Web.Api.Dto;

namespace Sdt.Web.Api.Controllers
{
    [Route("api/sprueche")]
    [ApiController]
    public class SpruecheController : ControllerBase
    {
        #region Members/Constructors

        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper; //Automapper

        public SpruecheController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #endregion

        #region GET

        [HttpGet("randomsdt")]
        public async Task<IActionResult> GetZufallSpruchDesTages()
        {
            var spruch = await _repository.Spruch.GetSpruchDesTagesAsync();
            
            return Ok(_mapper.Map<SpruchDesTagesDTO>(spruch));
        }

        #endregion
    }
}
