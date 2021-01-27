using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdt.Domain.Entities
{
    public class Autor
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutorId { get; set; }  //ID,Id, Klassename + Id => autom. Primärschlüssel

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Beschreibung { get; set; }
        public DateTime? Geburtsdatum { get; set; }

        public virtual IList<Spruch> Sprueche { get; set; } = new List<Spruch>();
    }
}
