using System;
using System.Linq;

namespace GadgetShop.Infrastructure.Entities
{
    public class EntityContext<T> : IEntityContext<T>
    {
        public IQueryable<T> Entities
        {
            get { throw new NotImplementedException(); }
        }

        public void Insert(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }


        public T GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
