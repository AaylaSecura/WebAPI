using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Sdt.Domain.Entities;
using Sdt.Web.Common.Validation;

namespace Sdt.Web.Api.Dto
{
    public class AutorDTO : AutorBaseDTO
    {
        public byte[] Photo { get; set; }
        public string PhotoMimeType { get; set; }
    }

    
}
