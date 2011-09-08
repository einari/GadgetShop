using System;
using System.Linq;
using NHibernate;
using NHibernate.Linq;

namespace GadgetShop.Infrastructure.Entities
{
    public class EntityContext<T> : IEntityContext<T>
    {
        ISession _session;

        public EntityContext(EntityContextConnection connection)
        {
            _session = connection.SessionFactory.OpenSession();
        }


        public IQueryable<T> Entities
        {
            get
            {
                var queryable = _session.Linq<T>();
                return queryable;
            }
        }

        public void Insert(T entity)
        {
            _session.Save(entity);
        }

        public void Update(T entity)
        {
            _session.Update(entity);
        }

        public void Delete(T entity)
        {
            _session.Delete(entity);
        }

        public void Commit()
        {
            _session.Flush();
        }


        public T GetById(Guid id)
        {
            return _session.Get<T>(id);
        }

		public void Dispose()
		{
			_session.Flush();
			_session.Close();
			_session = null;
		}
    }
}
