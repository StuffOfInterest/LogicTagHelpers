using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Content to display when no case statements match switch statement condition.
	/// </summary>
	[HtmlTargetElement("default", ParentTag = "switch")]
	public class DefaultTagHelper : TagHelper
	{
		/// <summary>
		/// Internal tag helper processing.
		/// </summary>
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var switchContext = (SwitchContext) context.Items[SwitchContext.ContextKey];
			
			if (switchContext == null)
			{
				throw new LogicTagHelperException("Default statement inside of switch with no valid expression.");
			}

			if (switchContext.HasDefault)
			{
				throw new LogicTagHelperException($"Duplicate default definition in switch statement.");
			}

			if (!switchContext.HasMatch)
			{
				switchContext.MatchedContent = await output.GetChildContentAsync();
				switchContext.HasMatch = true;
			}

			switchContext.HasDefault = true;
			output.SuppressOutput();
		}
	}
}