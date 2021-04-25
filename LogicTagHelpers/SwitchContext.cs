using System.Collections.Generic;
using Microsoft.AspNetCore.Html;

namespace LogicTagHelpers
{
	internal class SwitchContext
	{
		public const string ContextKey = "Select-Context";

		public object Expression { get; set; }
		public bool HasMatch { get; set; }
		public bool HasDefault { get; set; }
		public IHtmlContent MatchedContent { get; set; }
		public IList<object> Values { get; } = new List<object>();
	}
}