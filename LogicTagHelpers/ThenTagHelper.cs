using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Code to show if condition is met.
	/// </summary>
	[HtmlTargetElement("then", ParentTag = "if")]
	public class ThenTagHelper : TagHelper
	{
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var iteContext = (IfThenElseContext) context.Items[IfThenElseContext.ContextKey];
			var iteCondition = (bool) context.Items[IfThenElseContext.ConditionKey];
			iteContext.HasChildTags = true;

			if (iteCondition)
			{
				var childContent = await output.GetChildContentAsync();
				iteContext.Result = childContent.GetContent();
			}

			output.TagName = null;
			output.SuppressOutput();
		}
	}
}