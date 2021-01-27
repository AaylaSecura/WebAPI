using System.ComponentModel.DataAnnotations;

namespace Sdt.Domain.Entities
{
    public class Spruch
    {
        public int SpruchId { get; set; }

        [Required]
        public string SpruchText { get; set; }
        public virtual Autor Autor { get; set; }
        public int AutorId { get; set; }
    }
}