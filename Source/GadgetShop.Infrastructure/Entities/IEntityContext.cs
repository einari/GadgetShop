using System;
using System.Linq;

namespace GadgetShop.Infrastructure.Entities
{
    public interface IEntityContext<T> : IDisposable
    {
        IQueryable<T> Entities { get; }
        T GetById(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Commit();
    }
}
