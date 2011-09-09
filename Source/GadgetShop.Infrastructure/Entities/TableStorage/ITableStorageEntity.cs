using System;

namespace GadgetShop.Infrastructure.Entities.TableStorage
{
    public interface ITableStorageEntity
    {
        string PartitionKey { get; set; }
        string RowKey { get; set; }
        DateTime Timestamp { get; set; }
    }
}
