using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Sdt.Web.Common.Validation;

namespace Sdt.Web.Api.Dto
{
    public class AutorBaseDTO
    {
        public int AutorId { get; set; }

        [Required(ErrorMessage = "Bitte geben Sie einen Namen ein!")]
        [StringLength(50)]
        [ForbiddenInput("administrator,admin,root,god")]
        public string Name { get; set; }

        [Required]
        public string Beschreibung { get; set; }

        [NoFutureDate(ErrorMessage = @"{0} darf nicht in der Zukunft liegen")]
        public DateTime? Geburtsdatum { get; set; }

        public virtual List<SpruchDTO> Sprueche { get; set; }
    }
}
