using System;

namespace LogicTagHelpers
{
	/// <summary>
	/// Exception returned when misconfigured logic tag helper is invoked.
	/// </summary>
	public class LogicTagHelperException : Exception
	{
		public LogicTagHelperException()
		{
		}

		public LogicTagHelperException(string message) : base(message)
		{
		}
	}
}