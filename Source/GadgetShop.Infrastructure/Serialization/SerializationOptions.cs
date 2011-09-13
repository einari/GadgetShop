using System;

namespace GadgetShop.Infrastructure.Serialization
{
	public class SerializationOptions
	{
		public Func<Type, string, bool>	ShouldSerializeProperty = (t, p) => true;
	}
}