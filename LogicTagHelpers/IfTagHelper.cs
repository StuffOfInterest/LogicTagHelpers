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

			var iteContext = new IfThenElseContext();
			context.Items[IfThenElseContext.ContextKey] = iteContext;
			context.Items[IfThenElseContext.ConditionKey] = Condition;
			var childContent = await output.GetChildContentAsync();

			if (iteContext.Result != null)
			{
				output.Content.SetHtmlContent(iteContext.Result);
			}
			else
			{
				if (iteContext.HasChildTags || !Condition)
				{
					output.SuppressOutput();
					return;
				}

				output.Content.SetHtmlContent(childContent.GetContent());
			}
		}
	}
}