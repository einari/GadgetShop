namespace GadgetShop.Infrastructure.Entities.TableStorage
{
    public class EntityMap<T>
    {
        PropertyMap<T> _partitionKey;
        PropertyMap<T> _rowKey;

        public EntityMap()
        {
        }

        public PropertyMap<T> PartitionKey
        {
            get
            {
                if (_partitionKey == null)
                    _partitionKey = new PropertyMap<T>();

                return _partitionKey;
            }
        }

        public PropertyMap<T> RowKey
        {
            get
            {
                if (_rowKey == null)
                    _rowKey = new PropertyMap<T>();

                return _rowKey;
            }
        }
    }
}
