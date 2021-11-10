using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;

namespace Verbose.Utility {

	public class TestMe {
		public string AString {  get; set; }
		public int AnInt {  get; set; }
		public char AChar {  get; set; }
	}

	[TestClass]
	public class TestUtilsTest {

		[TestMethod]
		public void GetProjectDirectory() {
			string value = TestUtils.GetProjectDirectory();
			Assert.IsTrue( value.EndsWith("VerboseTests") );
		}

		[TestMethod]
		public void AsString() {

			TestMe work = new TestMe();
			work.AString = "some-value";
			work.AnInt = 123;
			work.AChar = 'X';

			Assert.AreEqual(
				"{\"AChar\":\"X\",\"AnInt\":123,\"AString\":\"some-value\"}", 
				TestUtils.AsString(work) );
		}

		[TestMethod]
		public void AsString_zeroCharIssue() {

			TestMe work = new TestMe();

			Assert.AreEqual(
				"{\"AChar\":\"\\u0000\",\"AnInt\":0,\"AString\":null}", 
				TestUtils.AsString(work) );		
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
    				"}",  TestUtils.AsPrettyString(work) );
		}

	
		[TestMethod]
		public void ToCodeString() { 

			Assert.AreEqual(
				"\"hi\"",
				TestUtils.ToCodeString("hi") );

			Assert.AreEqual(
				"\"hi\\n\"+\n" +
				"\t\t\t\t\"thEre\"",
				TestUtils.ToCodeString("hi\nthEre") );

			Assert.AreEqual(
				"\"hi\\r\\n\"+\n" +
				"\t\t\t\t\"thEre\"",
				TestUtils.ToCodeString("hi\r\nthEre") );

			Assert.AreEqual(
				"\"hi\\n\"+\n" +
				"\t\t\t\t\"\\n\"+\n" +
				"\t\t\t\t\"thEre\"",
				TestUtils.ToCodeString("hi\n\nthEre") );

			Assert.AreEqual(
				"\"\\n\"+\n" +
				"\t\t\t\t\"thE\\\"re\\n\"+\n" +
				"\t\t\t\t\"\"",
				TestUtils.ToCodeString("\nthE\"re\n") );

			Assert.AreEqual(
				"\"here [\0]\"",
				TestUtils.ToCodeString("here [\0]"));

			Assert.AreEqual(
				"\"here [\u0000]\"",
				TestUtils.ToCodeString("here [\u0000]"));

			Assert.AreEqual(
				"\"here [\u0000] and [\u0000]\"",
				TestUtils.ToCodeString("here [\u0000] and [\u0000]"));
		}
	}

}
