using System;
using System.Linq.Expressions;
using GadgetShop.Infrastructure.Extensions;
using System.Reflection;

namespace GadgetShop.Infrastructure.Entities.TableStorage
{
    public class PropertyMap<T>
    {
        Expression<Func<T, object>> _expression;
        PropertyInfo _propertyInfo;

        public void ToProperty(Expression<Func<T, object>> expression)
        {
            _expression = expression;
            _propertyInfo = expression.GetPropertyInfo();
        }

        public object GetValue(T entity)
        {
            return _propertyInfo.GetValue(entity, null);
        }

        public void SetValue(T entity, object value)
        {
            object actualValue;
            if (_propertyInfo.PropertyType == typeof(Guid))
                actualValue = Guid.Parse(value.ToString());
            else
                actualValue = Convert.ChangeType(value, _propertyInfo.PropertyType);
           
            _propertyInfo.SetValue(entity, actualValue, null);
        }
    }
}
