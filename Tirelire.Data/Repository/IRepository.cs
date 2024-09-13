using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Tirelire.Data.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        //T - Fabricant
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, string? includeProps = null);
        T Get(Expression<Func<T,bool>> filter, string? includeProps = null, bool tracked = false);
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
    }
}
