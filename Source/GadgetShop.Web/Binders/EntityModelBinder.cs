using System.Web.Mvc;
using GadgetShop.Infrastructure.Entities;
using System;

namespace GadgetShop.Web.Binders
{
    public class EntityModelBinder<T> : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("Id");
            if (value != null)
            {
                var id = (Guid)value.ConvertTo(typeof(Guid));
                var entityContext = DependencyResolver.Current.GetService<IEntityContext<T>>();
                var entity = entityContext.GetById(id);
                return entity;
            }

            return null;
        }
    }
}