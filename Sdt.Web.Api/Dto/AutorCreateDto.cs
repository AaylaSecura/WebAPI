using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Sdt.Web.Api.Dto
{
    public class AutorCreateDto : AutorBaseDTO
    {
        public IFormFile Photo { get; set; }
    }
}
