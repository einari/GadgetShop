using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.Practices.ServiceLocation;

namespace GadgetShop.Infrastructure.Serialization
{
	public class SerializerContractResolver : DefaultContractResolver
	{
		readonly IServiceLocator _serviceLocator;
		readonly SerializationOptions _options;

        public SerializerContractResolver(IServiceLocator serviceLocator, SerializationOptions options)
		{
			_serviceLocator = serviceLocator;
			_options = options;
		}


		protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
		{
			var properties = base.CreateProperties(type, memberSerialization);
			if( _options != null )
				return properties.Where(p => _options.ShouldSerializeProperty(type, p.PropertyName)).ToList();

			return properties;
		}

		public override JsonContract ResolveContract(Type type)
		{
			var contract = base.ResolveContract(type);

			
			if (contract is JsonObjectContract)
			{
				var defaultCreator = contract.DefaultCreator;

				contract.DefaultCreator = () =>
				                          	{
				                          		try
				                          		{
				                          			return _serviceLocator.GetInstance(type);
				                          		}
				                          		catch
				                          		{
				                          			return defaultCreator();
				                          		}
				                          	};
			}

			return contract;
		}
	}
}