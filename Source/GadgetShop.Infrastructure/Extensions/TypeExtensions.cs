using System;

namespace GadgetShop.Infrastructure.Extensions
{
	/// <summary>
	/// Provides a set of methods for working with <see cref="Type">types</see>
	/// </summary>
	public static class TypeExtensions
	{
		/// <summary>
		/// Check if a type implements a specific interface
		/// </summary>
		/// <typeparam name="T">Interface to check for</typeparam>
		/// <param name="type">Type to check</param>
		/// <returns>True if the type implements the interface, false if not</returns>
		public static bool HasInterface<T>(this Type type)
		{
		    var hasInterface = type.HasInterface(typeof (T));
			return hasInterface;
		}

        /// <summary>
        /// Check if a type implements a specific interface
        /// </summary>
        /// <param name="type">Type to check</param>
        /// <param name="interfaceType">Interface to check for</param>
        /// <returns>True if the type implements the interface, false if not</returns>
        public static bool HasInterface(this Type type, Type interfaceType)
        {
            var hasInterface = type.GetInterface(interfaceType.Name, false) != null;
            return hasInterface;
        }

	}
}