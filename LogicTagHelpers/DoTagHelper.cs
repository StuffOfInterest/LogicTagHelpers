using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Do loop render block of code until condition is no longer met.
	/// </summary>
	public class DoTagHelper : TagHelper
	{
		/// <summary>
		/// Function to evaluate exit condition.
		/// Inner content will render as long as the condition returns true.
		/// </summary>
		public Func<bool> Condition { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if (Condition == null)
			{
				throw new LogicTagHelperException("Condition may not be null.");
			}

			output.TagName = null;
			output.Content.Clear();

			do
			{
				var childContent = await output.GetChildContentAsync(false);
				output.Content.AppendHtml(childContent);
			} while (Condition.Invoke());
		}
	}
}