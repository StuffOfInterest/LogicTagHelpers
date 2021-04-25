using System.Collections.Generic;

namespace LogicTagHelpers
{
	/// <summary>
	/// Generic implementation of a foreach context which can take any iterable object as a generic type.
	/// </summary>
	/// <typeparam name="T">Type of object to iterate over.</typeparam>
	public class ForeachContext<T> : IForeachContext
	{
		public ForeachContext()
		{
		}

		public ForeachContext(IEnumerable<T> items)
		{
			Collection = items;
		}

		private IEnumerator<T> _enumerator;

		public IEnumerable<T> Collection { get; set; }
		public T Item { get; set; }

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