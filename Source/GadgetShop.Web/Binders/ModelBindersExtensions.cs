
using System.Web.Mvc;
namespace GadgetShop.Web.Binders
{
    public static class ModelBindersExtensions
    {
        public static void AddFor<T>(this ModelBinderDictionary dictionary)
        {
            dictionary.Add(typeof(T), new EntityModelBinder<T>());
        }
    }
}