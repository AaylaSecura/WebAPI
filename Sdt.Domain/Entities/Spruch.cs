namespace Sdt.Domain.Entities
{
    public class Spruch
    {
        public int SpruchId { get; set; }
        public string SpruchText { get; set; }
        public virtual Autor Autor { get; set; }
        public int AutorId { get; set; }
    }
}