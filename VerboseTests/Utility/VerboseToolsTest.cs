

namespace Verbose.Utility {

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using System;

	using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


	public class TestMe {
		public string AString {  get; set; }
		public int AnInt {  get; set; }
		public char AChar {  get; set; }
	}

	[TestClass]
	public class VerboseToolsTest {

		[TestMethod]
		public void AsString() {

			TestMe work = new TestMe();
			work.AString = "some-value";
			work.AnInt = 123;
			work.AChar = 'X';

			Assert.AreEqual(
				"{\"AChar\":\"X\",\"AnInt\":123,\"AString\":\"some-value\"}", 
				VerboseTools.AsString(work) );
		}

		[TestMethod]
		public void AsString_zeroCharIssue() {

			TestMe work = new TestMe();

			Assert.AreEqual(
				"{\"AChar\":\"\\u0000\",\"AnInt\":0,\"AString\":null}", 
				VerboseTools.AsString(work) );		
		}

		
		[TestMethod]
		public void AsPrettyString() {

			TestMe work = new TestMe();
			work.AString = "some-value";
			work.AnInt = 123;
			work.AChar = 'X';

			VerboseAsserts.StringsAreEqual("{\n"+
    				"  \"AChar\": \"X\",\n"+
    				"  \"AnInt\": 123,\n"+
    				"  \"AString\": \"some-value\"\n"+
    				"}",  VerboseTools.AsPrettyString(work) );
		}

	}

}
