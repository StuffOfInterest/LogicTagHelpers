using Microsoft.AspNetCore.Html;

namespace LogicTagHelpers
{
	internal class SwitchContext
	{
		public const string ContextKey = "Select-Context";

		public object Expression { get; set; }
		public bool HasMatch { get; set; }
		public IHtmlContent MatchedContent { get; set; }
		public IHtmlContent DefaultContent { get; set; }
	}
}