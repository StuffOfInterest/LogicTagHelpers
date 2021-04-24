using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Conditionally include inner content.
	/// </summary>
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
			context.Items["IfThenElse-Context"] = iteContext;
			context.Items["IfThenElse-Condition"] = Condition;
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

		public class IfThenElseContext
		{
			public bool HasChildTags { get; set; }
			public string Result { get; set; }
		}
	}

	/// <summary>
	/// Code to show if condition is met.
	/// </summary>
	[HtmlTargetElement("then", ParentTag = "if")]
	public class ThenTagHelper : TagHelper
	{
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var iteContext = (IfTagHelper.IfThenElseContext)context.Items["IfThenElse-Context"];
			var iteCondition = (bool)context.Items["IfThenElse-Condition"];
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

	/// <summary>
	/// Code to show if condition is not met.
	/// </summary>
	[HtmlTargetElement("else", ParentTag = "if")]
	public class ElseTagHelper : TagHelper
	{
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var iteContext = (IfTagHelper.IfThenElseContext)context.Items["IfThenElse-Context"];
			var iteCondition = (bool)context.Items["IfThenElse-Condition"];
			iteContext.HasChildTags = true;

			if (!iteCondition)
			{
				var childContent = await output.GetChildContentAsync();
				iteContext.Result = childContent.GetContent();
			}

			output.TagName = null;
			output.SuppressOutput();
		}
	}
}
