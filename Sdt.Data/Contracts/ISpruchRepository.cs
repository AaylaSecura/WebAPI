using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdt.Domain.Entities;

namespace Sdt.Data.Contracts
{
    public interface ISpruchRepository : IRepositoryBase<Spruch, int>
    {
        Task<Spruch> GetSpruchWithAutorAsync(int spruchId);
        Task<Spruch> GetSpruchDesTagesAsync();
    }
}
