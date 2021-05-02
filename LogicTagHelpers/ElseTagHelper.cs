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
		/// <summary>
		/// Internal tag helper processing.
		/// </summary>
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var ifContext = (IfContext) context.Items[IfContext.ContextKey];

			if (ifContext.HasElse)
			{
				throw new LogicTagHelperException("Duplicate 'else' declaration in 'if' statement.");
			}

			if (!ifContext.Condition)
			{
				ifContext.Result = await output.GetChildContentAsync();
			}

			ifContext.HasElse = true;
			output.SuppressOutput();
		}
	}
}