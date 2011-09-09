using System;
using System.Data.Services.Common;
using System.Linq;
using Castle.DynamicProxy;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.StorageClient;

namespace GadgetShop.Infrastructure.Entities.TableStorage
{
    public class EntityContext<T> : TableServiceContext, IEntityContext<T>
        where T : IHaveId
    {
        CloudStorageAccount _account;
        string _entitySetName;
        IQueryable<T> _entities;
        EntityMap<T> _map;

        public EntityContext(CloudStorageAccount account)
            : base(account.TableEndpoint.AbsoluteUri, account.Credentials)
        {
            IgnoreMissingProperties = true;

            _account = account;
            RetryPolicy = RetryPolicies.Retry(3, TimeSpan.FromSeconds(1));

            _entitySetName = typeof(T).Name;
            _entities = CreateQuery<T>(_entitySetName);

            _map = GetEntityMap();

            CreateTableIfNotExist();
        }

        EntityMap<T> GetEntityMap()
        {
            var entityType = typeof(T);
            var types = entityType.Assembly.GetTypes();
            var mapType = types.Where(t => typeof(EntityMap<T>).IsAssignableFrom(t)).SingleOrDefault();
            if (mapType != null)
                return (EntityMap<T>)Activator.CreateInstance(mapType);

            return null;
        }


        void CreateTableIfNotExist()
        {
            var client = new CloudTableClient(_account.TableEndpoint.AbsoluteUri, _account.Credentials);
            client.CreateTableIfNotExist(_entitySetName);
        }

        IQueryable<T> IEntityContext<T>.Entities { get { return _entities; } }

        object GetActualEntity(T entity)
        {
            var generator = new ProxyGenerator();
            var options = new ProxyGenerationOptions();
            options.AddMixinInstance(entity);
            options.AddMixinInstance(new Entity<T>(entity, _map));

            options.AttributesToAddToGeneratedTypes.Add(new DataServiceEntityAttribute());
            options.AttributesToAddToGeneratedTypes.Add(new DataServiceKeyAttribute("PartitionKey", "RowKey"));
            var actualEntity = generator.CreateClassProxy(typeof(T), options);

            return actualEntity;
        }

        public void Insert(T entity)
        {
            var actualEntity = GetActualEntity(entity);
            AddObject(_entitySetName, actualEntity);
        }

        public void Update(T entity)
        {
            var actualEntity = GetActualEntity(entity);
            UpdateObject(actualEntity);
        }

        public void Delete(T entity)
        {
            var actualEntity = GetActualEntity(entity);
            DeleteObject(actualEntity);
        }

        public void Commit()
        {
            SaveChanges();
        }


        public T GetById(Guid id)
        {
            return ((IEntityContext<T>)this).Entities.Where(e => e.Id == id).Single();
        }

        public void Dispose()
        {
            
        }
    }
}
