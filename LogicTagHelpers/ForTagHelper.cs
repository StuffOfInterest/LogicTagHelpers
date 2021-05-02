using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// For loop rendering block of code as long as condition is met.
	/// </summary>
	public class ForTagHelper : TagHelper
	{
		/// <summary>
		/// Initialize variable for loop control.
		/// </summary>
		public Action Initialize { get; set; }

		/// <summary>
		/// Function to evaluate exit condition.
		/// Inner content will render as long as the condition returns true.
		/// </summary>
		public Func<bool> Condition { get; set; }

		/// <summary>
		/// Update to perform at end of each pass through the loop.
		/// </summary>
		public Action Update { get; set; }

		/// <summary>
		/// Internal tag helper processing.
		/// </summary>
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if (Condition == null)
			{
				throw new LogicTagHelperException("Condition may not be null.");
			}

			Initialize?.Invoke();

			output.TagName = null;
			output.Content.Clear();

			while (Condition.Invoke())
			{
				var childContent = await output.GetChildContentAsync(false);
				output.Content.AppendHtml(childContent);

				Update?.Invoke();
			}
		}
	}
}