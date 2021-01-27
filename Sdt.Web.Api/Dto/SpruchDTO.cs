using System.ComponentModel.DataAnnotations;
using Sdt.Domain.Entities;

namespace Sdt.Web.Api.Dto
{
    public class SpruchDTO
    {
        public int SpruchId { get; set; }

        [Required]
        public string SpruchText { get; set; }
        public string AutorName { get; set; }
        public int AutorId { get; set; }
    }
}