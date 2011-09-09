
using System.Web.Mvc;
using GadgetShop.Infrastructure.Entities;
namespace GadgetShop.Web.Binders
{
    public static class ModelBindersExtensions
    {
        public static void AddFor<T>(this ModelBinderDictionary dictionary) where T:IHaveId
        {
            dictionary.Add(typeof(T), new EntityModelBinder<T>());
        }
    }
}