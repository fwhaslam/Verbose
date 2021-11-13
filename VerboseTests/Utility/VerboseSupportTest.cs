
namespace Verbose.Utility {
	
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using System;

	using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


	[TestClass]
	public class VerboseSupportTest {

		[TestMethod]
		public void VerboseFail() {
			try {
				VerboseSupport.VerboseFail("Boom!");
				Assert.Fail("Must not reach this line!");
			} 
			catch ( VerboseAssertionException ex) {
				AreEqual( "Boom!", ex.Message );
			}
		}

		[TestMethod]
		public void GetProjectDirectory() {
			string value = VerboseSupport.GetProjectDirectory();
			Assert.IsTrue( value.EndsWith("VerboseTests") );
		}

	
		[TestMethod]
		public void ToCodeString() { 

			Assert.AreEqual(
				"\"hi\"",
				VerboseSupport.ToCodeString("hi") );

			Assert.AreEqual(
				"\"hi\\n\"+\n" +
				"\t\t\t\t\"thEre\"",
				VerboseSupport.ToCodeString("hi\nthEre") );

			Assert.AreEqual(
				"\"hi\\r\\n\"+\n" +
				"\t\t\t\t\"thEre\"",
				VerboseSupport.ToCodeString("hi\r\nthEre") );

			Assert.AreEqual(
				"\"hi\\n\"+\n" +
				"\t\t\t\t\"\\n\"+\n" +
				"\t\t\t\t\"thEre\"",
				VerboseSupport.ToCodeString("hi\n\nthEre") );

			Assert.AreEqual(
				"\"\\n\"+\n" +
				"\t\t\t\t\"thE\\\"re\\n\"+\n" +
				"\t\t\t\t\"\"",
				VerboseSupport.ToCodeString("\nthE\"re\n") );

			Assert.AreEqual(
				"\"here [\0]\"",
				VerboseSupport.ToCodeString("here [\0]"));

			Assert.AreEqual(
				"\"here [\u0000]\"",
				VerboseSupport.ToCodeString("here [\u0000]"));

			Assert.AreEqual(
				"\"here [\u0000] and [\u0000]\"",
				VerboseSupport.ToCodeString("here [\u0000] and [\u0000]"));
		}
	}

}
