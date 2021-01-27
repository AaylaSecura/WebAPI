using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sdt.Domain.Entities;

namespace Sdt.Web.Api.Dto
{
    public static class DtoFactory
    {
        public static AutorDTO CreateAutorDto(Autor autor)
        {
            return new AutorDTO
            {
                AutorId = autor.AutorId,
                Name = autor.Name,
                Beschreibung = autor.Beschreibung,
                Geburtsdatum = autor.Geburtsdatum,
                Photo = autor.Photo,
                PhotoMimeType = autor.PhotoMimeType,
                Sprueche = autor.Sprueche?.Select(CreateSpruchDto).ToList()
            };
        }

        private static SpruchDTO CreateSpruchDto(Spruch spruch)
        {
            return new SpruchDTO
            {
                SpruchId = spruch.SpruchId,
                SpruchText = spruch.SpruchText,
                AutorId = spruch.AutorId,
                AutorName = spruch.Autor?.Name
            };
        }
    }
}
