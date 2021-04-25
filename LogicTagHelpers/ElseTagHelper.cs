using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Code to show if condition is not met.
	/// </summary>
	[HtmlTargetElement("else", ParentTag = "if")]
	public class ElseTagHelper : TagHelper
	{
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var ifContext = (IfContext) context.Items[IfContext.ContextKey];
			ifContext.HasChildTags = true;

			if (!ifContext.Condition)
			{
				ifContext.Result = await output.GetChildContentAsync();
			}

			output.TagName = null;
			output.SuppressOutput();
		}
	}
}