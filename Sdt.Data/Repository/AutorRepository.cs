using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Sdt.Data.Context;
using Sdt.Data.Contracts;
using Sdt.Domain.Entities;

namespace Sdt.Data.Repository
{
    public class AutorRepository : RepositoryBase<Autor, int>, IAutorRepository
    {
        public AutorRepository(SdtDataContext sdtDataContext) : base(sdtDataContext)
        {}

        public void CreateAutor(Autor autor)
        {
            Add(autor);
        }

        public void DeleteAutor(Autor autor)
        {
            base.Delete(autor);
        }

        public async Task<IEnumerable<Autor>> GetAllAutorsAsync()
        {
            return await GetAll().Include(c => c.Sprueche).ToListAsync();
            //return await GetAll().ToListAsync();
        }

        public async Task<Autor> GetAutorByIdAsync(int autorId)
        {
            return await FindByCondition(autor => autor.AutorId.Equals(autorId)).SingleOrDefaultAsync();
        }

        public async Task<Autor> GetAutorWithQuotesAsync(int autorId)
        {
            return await FindByCondition(autor => autor.AutorId.Equals(autorId))
                .Include(c => c.Sprueche)
                .SingleOrDefaultAsync();
        }

        public void UpdateAutor(Autor autor)
        {
            Update(autor.AutorId, autor);
        }
    }
}
