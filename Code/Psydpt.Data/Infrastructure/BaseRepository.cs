using Psydpt.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Psydpt.Data.Infrastructure
{
    public class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey> 
        where TEntity: EntityBase
        //where TKey: class
    {

        protected IUnitOfWork _unitOfWork;


        public BaseRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public TEntity GetById(TKey id)
        {
            return _unitOfWork.Context.Set<TEntity>().Find(id);
        }



        public IEnumerable<TEntity> Get()
        {
            return _unitOfWork.Context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            if (entity.CreatedOn == null) { entity.CreatedOn = DateTime.Now; }
            _unitOfWork.Context.Set<TEntity>().Add(entity);
        }


        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entity.UpdatedOn = DateTime.Now;
            _unitOfWork.Context.Set<TEntity>().Attach(entity);
            _unitOfWork.Context.Entry(entity).State = EntityState.Modified;
        }


        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _unitOfWork.Context.Set<TEntity>().Attach(entity);
            _unitOfWork.Context.Set<TEntity>().Remove(entity);
        }


    }
}
