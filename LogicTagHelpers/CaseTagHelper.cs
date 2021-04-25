using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace LogicTagHelpers
{
	/// <summary>
	/// Content to display when value matches switch statement condition.
	/// </summary>
	[HtmlTargetElement("case", ParentTag = "switch")]
	public class CaseTagHelper : TagHelper
	{
		public object Value { get; set; }

		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var switchContext = (SwitchContext) context.Items[SwitchContext.ContextKey];

			if (switchContext.Values.Contains(Value))
			{
				throw new LogicTagHelperException($"Duplicate value '{Value}' in switch statement.");
			}

			if (!switchContext.HasMatch && Value.Equals(switchContext.Expression))
			{
				switchContext.MatchedContent = await output.GetChildContentAsync();
				switchContext.HasMatch = true;
			}

			switchContext.Values.Add(Value);
			output.SuppressOutput();
		}
	}
}