using System.Collections.Generic;

namespace LogicTagHelpers
{
	/// <summary>
	/// Generic implementation of a foreach context which can take any iterable object as a generic type.
	/// </summary>
	/// <typeparam name="T">Type of object to iterate over.</typeparam>
	public class ForeachContext<T> : IForeachContext
	{
		/// <summary>
		/// Create empty iterator context.
		/// Exception will be thrown if context is used without having the collection property set.
		/// </summary>
		public ForeachContext()
		{
		}

		/// <summary>
		/// Create iterator context with collection to iterate across.
		/// </summary>
		/// <param name="items">Type of object used in collection.  Also used for type of item property.</param>
		public ForeachContext(IEnumerable<T> items)
		{
			Collection = items;
		}

		private IEnumerator<T> _enumerator;

		/// <summary>
		/// Collection of objects to iterate over using 'foreach' loop.
		/// </summary>
		public IEnumerable<T> Collection { get; set; }

		/// <summary>
		/// Single item to present to inner content of 'foreach' loop.
		/// </summary>
		public T Item { get; set; }

		/// <summary>
		/// Loads next item into item property.
		/// Not intended for direct use.
		/// </summary>
		/// <returns>Boolean indicating if another item is available.</returns>
		public bool LoadNext()
		{
			var enumerator = _enumerator ??= Collection.GetEnumerator();
			var result = enumerator.MoveNext();
			if (result)
			{
				Item = enumerator.Current;
			}

			return result;
		}
	}
}