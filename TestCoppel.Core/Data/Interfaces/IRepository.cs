using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestCoppel.Core.Data.Interfaces
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        TEntity Add(TEntity entity);

        void Delete(TEntity entityToDelete);

        TEntity GetById(object id);

        void Update(TEntity entityToUpdate);
    }
}
