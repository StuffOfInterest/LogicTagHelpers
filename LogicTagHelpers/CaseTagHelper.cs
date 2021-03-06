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
		/// <summary>
		/// Value to compare to the 'switch' statement expression.
		/// Block only included when matched.
		/// </summary>
		public object Value { get; set; }

		/// <summary>
		/// Internal tag helper processing.
		/// </summary>
		public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
		{
			var switchContext = (SwitchContext) context.Items[SwitchContext.ContextKey];

			if (switchContext == null)
			{
				throw new LogicTagHelperException("Case statement inside of switch with no valid expression.");
			}

			if (Value.GetType() != switchContext.Expression.GetType())
			{
				throw new LogicTagHelperException(
					$"Case statement value type '{Value.GetType().Name}' not equal to switch statement expression type '{switchContext.Expression.GetType().Name}'.");
			}

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