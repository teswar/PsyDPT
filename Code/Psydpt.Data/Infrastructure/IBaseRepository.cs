using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Data.Infrastructure
{
    public interface IBaseRepository<TEntity, TKey>
        where TEntity : class
        where TKey : class
    {
        void Create(TEntity entity);
        TEntity GetById(TKey id);
        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
