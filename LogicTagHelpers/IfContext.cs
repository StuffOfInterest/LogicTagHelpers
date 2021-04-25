using Microsoft.AspNetCore.Html;

namespace LogicTagHelpers
{
	internal class IfContext
	{
		public const string ContextKey = "IfThenElse-Context";

		public bool Condition { get; set; }
		public bool HasThen { get; set; }
		public bool HasElse { get; set; }
		public IHtmlContent Result { get; set; }
	}
}