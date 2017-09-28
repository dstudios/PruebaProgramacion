using System.Data;
using System.Data.Entity;
using System.Linq;
using TestCoppel.Core.Data.Interfaces;
using System.Data.Entity.Migrations;
using Ninject;

namespace TestCoppel.Core.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class, ISoftDeleteEntity
    {
        [Inject]
        public coppelDbContext Context { protected get; set; }

        public virtual TEntity Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
            Context.Entry(entity).State = EntityState.Added;
            Context.SaveChanges();
            return entity;
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            entityToDelete.Estatus = false;
            Update(entityToDelete as TEntity);
        }

        public virtual TEntity GetById(object id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            Context.Set<TEntity>().Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
            Context.SaveChanges();
        }

        protected IQueryable<TEntity> ReadAll()
        {
            return Context.Set<TEntity>();
        }
    }
}
