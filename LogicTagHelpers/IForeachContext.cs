namespace LogicTagHelpers
{
	/// <summary>
	/// Context for 'foreach' tag helper which holds the collection to iterator over
	/// and presents each item to the tag helper content.
	/// </summary>
	public interface IForeachContext
	{
		bool LoadNext();
	}
}