using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LogicTagHelpers.Tests
{
	[TestClass]
	public class CreateClassTests
	{
		[TestMethod]
		public void CanCreateIfTagHelper()
		{
			// Act
			var result = new IfTagHelper();

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void CanCreateThenTagHelper()
		{
			// Act
			var result = new ThenTagHelper();

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void CanCreateElseTagHelper()
		{
			// Act
			var result = new ElseTagHelper();

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void CanCreateSwitchTagHelper()
		{
			// Act
			var result = new SwitchTagHelper();

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void CanCreateCaseTagHelper()
		{
			// Act
			var result = new CaseTagHelper();

			// Assert
			Assert.IsNotNull(result);
		}

		[TestMethod]
		public void CanCreateDefaultTagHelper()
		{
			// Act
			var result = new DefaultTagHelper();

			// Assert
			Assert.IsNotNull(result);
		}
	}
}