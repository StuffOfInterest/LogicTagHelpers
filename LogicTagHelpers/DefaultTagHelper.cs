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
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var switchContext = (SwitchContext) context.Items[SwitchContext.ContextKey];


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