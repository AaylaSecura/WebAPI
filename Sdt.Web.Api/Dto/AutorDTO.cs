using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Sdt.Domain.Entities;
using Sdt.Web.Common.Validation;

namespace Sdt.Web.Api.Dto
{
    public class AutorDTO
    {
        public int AutorId { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie einen Namen ein!")]
        [StringLength(50)]
        [ForbiddenInput("administrator,admin,root,god")]
        public string Name { get; set; }

        [Required]
        public string Beschreibung { get; set; }
        public DateTime? Geburtsdatum { get; set; }

        public virtual List<SpruchDTO> Sprueche { get; set; }

        public byte[] Photo { get; set; }
        public string PhotoMimeType { get; set; }
    }
}
