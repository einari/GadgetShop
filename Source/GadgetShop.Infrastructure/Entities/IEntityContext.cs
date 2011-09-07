using System.Linq;

namespace GadgetShop.Infrastructure.Entities
{
    public interface IEntityContext<T>
    {
        IQueryable<T> Entities { get; }
        T GetById(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Commit();
    }
}
