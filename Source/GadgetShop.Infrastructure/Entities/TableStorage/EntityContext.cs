using System.Linq;
using System;

namespace GadgetShop.Infrastructure.Entities.TableStorage
{
    public class EntityContext<T> : IEntityContext<T>
    {
        public IQueryable<T> Entities
        {
            get { throw new System.NotImplementedException(); }
        }

        public void Insert(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Commit()
        {
            throw new System.NotImplementedException();
        }


        public T GetById(Guid id)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}
