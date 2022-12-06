//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//

namespace Verbose.Utility {
	
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using System;
	using System.Collections.Generic;

	using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


	[TestClass]
	public class VerboseSupportTest {

		[TestMethod]
		public void VerboseFail() {
			try {
				VerboseSupport.VerboseFail("Boom!");
				Fail("Must not reach this line!");
			} 
			catch ( VerboseAssertionException ex) {
				AreEqual( "Boom!", ex.Message );
			}
		}

		[TestMethod]
		public void First() { 
			int[] values = {1,2,3};
			List<int> list = new List<int>( values );	

			// assertions
			Assert.AreEqual( 1, VerboseSupport.First(list) );
		}

		[TestMethod]
		public void Last() {
			int[] values = {1,2,3};
			List<int> list = new List<int>( values );	

			// assertions
			Assert.AreEqual( 3, VerboseSupport.Last(list) );
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
