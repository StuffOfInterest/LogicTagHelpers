using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTagHelpers.Tests
{
	[TestClass]
	public class ForeachContextTests
	{
		[TestMethod]
		public void CanGetFirstRecord()
		{
			// Arrange
			var list = new[] {"one", "two", "three"};
			var context = new ForeachContext<string>(list);

			// Act
			var result = context.LoadNext();

			// Assert
			Assert.IsTrue(result);
			Assert.AreEqual("one", context.Item);
		}

		[TestMethod]
		public void CanGetSecondRecord()
		{
			// Arrange
			var list = new[] { "one", "two", "three" };
			var context = new ForeachContext<string>(list);
			context.LoadNext();

			// Act
			var result = context.LoadNext();

			// Assert
			Assert.IsTrue(result);
			Assert.AreEqual("two", context.Item);
		}

		[TestMethod]
		public void AfterLastRecordReturnsFalse()
		{
			// Arrange
			var list = new[] { "one", "two" };
			var context = new ForeachContext<string>(list);
			context.LoadNext();
			context.LoadNext();

			// Act
			var result = context.LoadNext();

			// Assert
			Assert.IsFalse(result);
			Assert.AreEqual("two", context.Item);
		}
	}
}
