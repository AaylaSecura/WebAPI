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
    public class SpruchRepository : RepositoryBase<Spruch, int>, ISpruchRepository
    {
        public SpruchRepository(SdtDataContext sdtDataContext) : base(sdtDataContext)
        { }

        public async Task<Spruch> GetSpruchDesTagesAsync()
        {
            var spruecheIds = await GetAll().Select(c => c.SpruchId).ToListAsync(); // 1,5,7,10
            var random = new Random();
            var zufallsSpruchId = spruecheIds[random.Next(0, spruecheIds.Count)]; // 0-Anzahl
            return await GetSpruchWithAutorAsync(zufallsSpruchId);
        }

        public async Task<Spruch> GetSpruchWithAutorAsync(int spruchId)
        {
            return await FindByCondition(spruch => spruch.SpruchId.Equals(spruchId))
                .Include(c => c.Autor).SingleOrDefaultAsync();
        }
    }
}
