using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Conditionally include inner content.
	/// Use child content directly without looking for &lt;then&gt; or &lt;else&gt; tags.
	/// </summary>
	public class IfThenTagHelper : TagHelper
	{
		/// <summary>
		/// Include if condition is true.
		/// </summary>
		public bool Condition { get; set; } = true;

		/// <summary>
		/// Internal tag helper processing.
		/// </summary>
		public override void Process(TagHelperContext context, TagHelperOutput output)
		{
			output.TagName = null;

			if (!Condition)
			{
				output.SuppressOutput();
			}
		}
	}
}