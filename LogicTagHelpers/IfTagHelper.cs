using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Conditionally include inner content.
	/// Use &lt;then&gt; or &lt;else&gt; to define content to include if condition evaluates true or false.
	/// </summary>
	[HtmlTargetElement("if")]
	[RestrictChildren("then", "else")]
	public class IfTagHelper : TagHelper
	{
		/// <summary>
		/// Include if condition is true.
		/// </summary>
		public bool Condition { get; set; } = true;

		/// <summary>
		/// Internal tag helper processing.
		/// </summary>
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = null;

			var ifContext = new IfContext {Condition = Condition};
			context.Items[IfContext.ContextKey] = ifContext;
			var childContent = await output.GetChildContentAsync();

			if (ifContext.Result != null)
			{
				output.Content.SetHtmlContent(ifContext.Result);
			}
			else
			{
				if (ifContext.HasThen || ifContext.HasElse || !Condition)
				{
					output.SuppressOutput();
					return;
				}

				output.Content.SetHtmlContent(childContent);
			}
		}
	}
}