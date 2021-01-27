using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Sdt.Data.Context;
using Sdt.Data.Contracts;

namespace Sdt.Data.Repository
{
    public class RepositoryBase<T, TKey> : IRepositoryBase<T, TKey> where T : class
    {
        private bool disposedValue;
        protected SdtDataContext SdtDataContext { get; set; }

        public RepositoryBase(SdtDataContext sdtDataContext) => SdtDataContext = sdtDataContext;

        public void Add(T entity)
        {
            SdtDataContext.Set<T>().Add(entity);  //z.B. context.Autoren.Add
        }

        public void Delete(T entity)
        {
            SdtDataContext.Set<T>().Remove(entity);
        }

        public bool Exists(TKey id)
        {
            return SdtDataContext.Set<T>().Find(id) != null;
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return SdtDataContext.Set<T>().Where(expression);
        }

        public IQueryable<T> GetAll()
        {
            return SdtDataContext.Set<T>();
        }

        public void Update(TKey id, T entity)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                    SdtDataContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~RepositoryBase()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
