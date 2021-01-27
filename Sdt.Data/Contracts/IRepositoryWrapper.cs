using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sdt.Data.Contracts
{
    public interface IRepositoryWrapper
    {
        IAutorRepository Autor { get; }
        Task<bool> SaveAsync();
    }
}
