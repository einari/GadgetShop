﻿using System;
using System.Collections.Generic;

namespace GadgetShop.Infrastructure.Serialization
{
	public interface ISerializer
	{
		/// <summary>
		/// Deserialize Json to a specific type from a <see cref="string"/>
		/// </summary>
		/// <typeparam name="T">Type to deserialize to</typeparam>
		/// <param name="json"><see cref="string"/> containing the Json</param>
		/// <param name="options">Options for the serializer</param>
		/// <returns>An deserialized</returns>
		T FromJson<T>(string json, SerializationOptions options = null);

		/// <summary>
		/// Deserialize Json to a specific type from a <see cref="string"/>
		/// </summary>
		/// <param name="type">Type to deserialize to</param>
		/// <param name="json"><see cref="string"/> containing the Json</param>
		/// <param name="options">Options for the serializer</param>
		/// <returns>A deserialized instance</returns>
		object FromJson(Type type, string json, SerializationOptions options = null);

		/// <summary>
		/// Deserialize Json into a specific instance
		/// </summary>
		/// <param name="instance">Instance to deserialize into</param>
		/// <param name="json"><see cref="string"/> containing the Json</param>
		/// <param name="options">Options for the serializer</param>
		void FromJson(object instance, string json, SerializationOptions options = null);

		/// <summary>
		/// Serialize an object to Json as a string
		/// </summary>
		/// <param name="instance">Instance to serialize</param>
		/// <param name="options">Options for the serializer</param>
		/// <returns><see cref="string"/> containing the serialized instance</returns>
		string ToJson(object instance, SerializationOptions options = null);

		/// <summary>
		/// Deserialize Json into a key/value dictionary
		/// </summary>
		/// <param name="json">Json to deserialize</param>
		/// <returns>A dictionary holding all properties and values in the Json</returns>
		IDictionary<string, object> GetKeyValuesFromJson(string json);
	}
}
