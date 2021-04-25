using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Include at most one section based on value of an expression.
	/// </summary>
	[HtmlTargetElement("switch")]
	[RestrictChildren("case", "default")]
	public class SwitchTagHelper : TagHelper
	{
		/// <summary>
		/// Expression to evaluate when choosing section of markup to display.
		/// </summary>
		public object Expression { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = null;

			var switchContext = new SwitchContext {Expression = Expression};
			context.Items[SwitchContext.ContextKey] = switchContext;

			// ReSharper disable once MustUseReturnValue
			await output.GetChildContentAsync();

			if (!switchContext.HasMatch)
			{
				output.SuppressOutput();
				return;
			}

			output.Content.SetHtmlContent(switchContext.MatchedContent);
		}
	}
}