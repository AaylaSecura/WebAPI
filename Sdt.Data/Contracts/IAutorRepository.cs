using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdt.Domain.Entities;

namespace Sdt.Data.Contracts
{
    public interface IAutorRepository : IRepositoryBase<Autor, int>
    {
        Task<IEnumerable<Autor>> GetAllAutorsAsync();
        Task<Autor> GetAutorByIdAsync(int autorId);
        Task<Autor> GetAutorWithQuotesAsync(int autorId);
        void CreateAutor(Autor autor);
        void UpdateAutor(Autor autor);
        void DeleteAutor(Autor autor);
    }
}
