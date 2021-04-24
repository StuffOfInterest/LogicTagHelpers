namespace LogicTagHelpers
{
	internal class IfThenElseContext
	{
		public const string ContextKey = "IfThenElse-Context";
		public const string ConditionKey = "IfThenElse-Condition";

		public bool HasChildTags { get; set; }
		public string Result { get; set; }
	}
}