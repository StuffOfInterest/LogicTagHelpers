using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Re-render block of code as long as condition evaluates to true.
	/// </summary>
	public class WhileTagHelper : TagHelper
	{
		/// <summary>
		/// Function to evaluate exit condition.
		/// Inner content will render as long as the condition returns true.
		/// </summary>
		public Func<bool> Condition { get; set; }

		/// <summary>
		/// Internal tag helper processing.
		/// </summary>
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			if (Condition == null)
			{
				throw new LogicTagHelperException("Condition may not be null.");
			}

			output.TagName = null;
			output.Content.Clear();

			while (Condition.Invoke())
			{
				var childContent = await output.GetChildContentAsync(false);
				output.Content.AppendHtml(childContent);
			}
		}
	}
}