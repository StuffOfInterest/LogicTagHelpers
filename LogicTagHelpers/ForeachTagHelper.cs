using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Perform 'foreach' iteration over a set of data.
	/// Inner content is rendered for each item in the iterator.
	/// </summary>
	[HtmlTargetElement("foreach")]
	public class ForeachTagHelper : TagHelper
	{
		/// <summary>
		/// Context which holds the collection to iterate over and a property for presenting the current item to the inner content.
		/// </summary>
		public IForeachContext Iterator { get; set; }

		/// <summary>
		/// Internal tag helper processing.
		/// </summary>
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if (Iterator == null)
			{
				throw new LogicTagHelperException("Iterator may not be null.");
			}

			output.TagName = null;
			output.Content.Clear();

			while (Iterator.LoadNext())
			{
				var childContent = await output.GetChildContentAsync(false);
				output.Content.AppendHtml(childContent);
			}
		}
	}
}