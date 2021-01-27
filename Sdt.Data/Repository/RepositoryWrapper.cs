using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdt.Data.Context;
using Sdt.Data.Contracts;

namespace Sdt.Data.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly SdtDataContext _sdtDataContext;
        private readonly IAutorRepository _autorRepository;
        public IAutorRepository Autor => _autorRepository;

        public RepositoryWrapper(SdtDataContext sdtDataContext, IAutorRepository autorRepository)
        {
            _sdtDataContext = sdtDataContext;
            _autorRepository = autorRepository;
        }

        public async Task<bool> SaveAsync()
        {
            return await _sdtDataContext.SaveChangesAsync() > 0;
        }
    }
}
