using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	[HtmlTargetElement("case", ParentTag = "switch")]
	public class CaseTagHelper : TagHelper
	{
		public object Value { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var switchContext = (SwitchContext)context.Items[SwitchContext.ContextKey];
			if (Value.Equals(switchContext.Expression))
			{
				switchContext.MatchedContent = await output.GetChildContentAsync();
				switchContext.HasMatch = true;
			}

			output.SuppressOutput();
		}
	}
}