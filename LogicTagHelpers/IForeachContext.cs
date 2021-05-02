namespace LogicTagHelpers
{
	/// <summary>
	/// Context for 'foreach' tag helper which holds the collection to iterator over
	/// and presents each item to the tag helper content.
	/// </summary>
	public interface IForeachContext
	{
		/// <summary>
		/// Loads next item into item property.
		/// Not intended for direct use.
		/// </summary>
		/// <returns>Boolean indicating if another item is available.</returns>
		bool LoadNext();
	}
}