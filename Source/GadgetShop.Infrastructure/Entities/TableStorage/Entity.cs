using System;

namespace GadgetShop.Infrastructure.Entities.TableStorage
{
    public class Entity<T> : ITableStorageEntity
    {
        T _entity;
        EntityMap<T> _map;

        string _partitionKey = "Undefined";
        string _rowKey = "Undefined";

        public Entity(T entity, EntityMap<T> map)
        {
            PartitionKey = "Something";
            RowKey = "Something Else";
            _map = map;

            _entity = entity;
        }

        public string PartitionKey 
        {
            get
            {
                if (_map != null)
                    return _map.PartitionKey.GetValue(_entity).ToString();

                return _partitionKey;
            }
            set
            {
                if (_map != null)
                    _map.PartitionKey.SetValue(_entity, value);

                _partitionKey = value;
            }
        }

        public string RowKey 
        {
            get
            {
                if (_map != null)
                    return _map.RowKey.GetValue(_entity).ToString();

                return _rowKey;
            }
            set
            {
                if (_map != null)
                    _map.RowKey.SetValue(_entity, value);

                _rowKey = value;
            }
        }
        public DateTime Timestamp { get; set; }
    }
}
