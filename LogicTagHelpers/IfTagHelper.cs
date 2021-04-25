using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Conditionally include inner content.
	/// </summary>
	[HtmlTargetElement("if")]
	public class IfTagHelper : TagHelper
	{
		/// <summary>
		/// Include if condition is true.
		/// </summary>
		public bool Condition { get; set; } = true;

		/// <summary>
		/// Use child content directly without looking for &lt;then&gt; or &lt;else&gt; tags.
		/// This will prevent evaluation of the inner markup if the condition is not met.
		/// </summary>
		public bool Direct { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = null;

			if (Direct)
			{
				if (!Condition)
				{
					output.SuppressOutput();
					return;
				}
			}

			var ifContext = new IfContext {Condition = Condition};
			context.Items[IfContext.ContextKey] = ifContext;
			var childContent = await output.GetChildContentAsync();

			if (ifContext.Result != null)
			{
				output.Content.SetHtmlContent(ifContext.Result);
			}
			else
			{
				if (ifContext.HasChildTags || !Condition)
				{
					output.SuppressOutput();
					return;
				}

				output.Content.SetHtmlContent(childContent);
			}
		}
	}
}