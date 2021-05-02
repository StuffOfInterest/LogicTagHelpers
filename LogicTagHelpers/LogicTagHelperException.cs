using System;

namespace LogicTagHelpers
{
	/// <summary>
	/// Exception returned when misconfigured logic tag helper is invoked.
	/// </summary>
	public class LogicTagHelperException : Exception
	{
		/// <summary>
		/// Create empty exception instance.
		/// </summary>
		public LogicTagHelperException()
		{
		}

		/// <summary>
		/// Create instance of exception with message.
		/// </summary>
		/// <param name="message">Message indicating reason for exception.</param>
		public LogicTagHelperException(string message) : base(message)
		{
		}
	}
}