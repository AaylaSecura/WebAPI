using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sdt.Web.UI.Model
{
    public class SpruchDesTagesViewModel
    {
        public int SpruchId { get; set; }

        public string SpruchText { get; set; }

        public int AutorId { get; set; }

        public string AutorName { get; set; }

        public string AutorBeschreibung { get; set; }

        public DateTime? AutorGeburtsdatum { get; set; }

        public byte[] AutorBild { get; set; }

        public string AutorBildType { get; set; }
    }
}
