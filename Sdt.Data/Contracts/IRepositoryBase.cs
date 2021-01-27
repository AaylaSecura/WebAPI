using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Sdt.Data.Contracts
{
    public interface IRepositoryBase<T, in TKey> : IDisposable where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(TKey id, T entity);
        IQueryable<T> GetAll();
        bool Exists(TKey id);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
    }
}
