namespace LogicTagHelpers
{
	internal class IfContext
	{
		public const string ContextKey = "IfThenElse-Context";

		public bool Condition { get; set; }
		public bool HasChildTags { get; set; }
		public string Result { get; set; }
	}
}