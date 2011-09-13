using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Practices.ServiceLocation;
using Newtonsoft.Json;

namespace GadgetShop.Infrastructure.Serialization
{
	public class Serializer : ISerializer
	{
        readonly IServiceLocator _serviceLocator;

		public Serializer(IServiceLocator serviceLocator)
		{
			_serviceLocator = serviceLocator;
		}

		public T FromJson<T>(string json, SerializationOptions options = null)
		{
			var serializer = CreateSerializer(options);
			using (var textReader = new StringReader(json))
			{
				using (var reader = new JsonTextReader(textReader))
				{
					var instance = _serviceLocator.GetInstance<T>();
					serializer.Populate(reader, instance);
					return instance;
				}
			}
		}

		public object FromJson(Type type, string json, SerializationOptions options = null)
		{
			var serializer = CreateSerializer(options);
			using (var textReader = new StringReader(json))
			{
				using (var reader = new JsonTextReader(textReader))
				{
                    var instance = _serviceLocator.GetInstance(type);
					serializer.Populate(reader, instance);
					return instance;
				}
			}
		}

		public void FromJson(object instance, string json, SerializationOptions options = null)
		{
			var serializer = CreateSerializer(options);
			using (var textReader = new StringReader(json))
			{
				using (var reader = new JsonTextReader(textReader))
				{
					serializer.Populate(reader, instance);
				}
			}
		}


		public string ToJson(object instance, SerializationOptions options = null)
		{
			using (var stringWriter = new StringWriter())
			{
				var serializer = CreateSerializer(options);
				serializer.Serialize(stringWriter, instance);
				var serialized = stringWriter.ToString();
				return serialized;
			}
		}

		public IDictionary<string, object> GetKeyValuesFromJson(string json)
		{
			return JsonConvert.DeserializeObject<Dictionary<string, object>>(json);
		}


		JsonSerializer CreateSerializer(SerializationOptions options)
		{
			var contractResolver = new SerializerContractResolver(_serviceLocator, options);
			var serializer = new JsonSerializer
			                 	{
			                 		TypeNameHandling = TypeNameHandling.Auto,
									ContractResolver = contractResolver
			                 	};
			return serializer;
		}
	}
}