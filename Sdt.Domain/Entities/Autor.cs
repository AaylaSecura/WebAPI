using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdt.Domain.Entities
{
    public class Autor
    {
        public int AutorId { get; set; }
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public DateTime? Geburtsdatum { get; set; }

        public IList<Spruch> Sprueche { get; set; } = new List<Spruch>();
    }
}
