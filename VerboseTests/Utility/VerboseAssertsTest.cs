//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//

namespace Verbose.Utility {

	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

	using System.Collections;
	using System.Collections.Generic;
	using System;

	[TestClass]
	public class VerboseAssertsTest {

		[TestMethod]
		public void StringsAreEqual_success() {
			VerboseAsserts.StringsAreEqual( "check", "check" );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StringsAreEqual_expectNull() {
			VerboseAsserts.StringsAreEqual( null, "check" );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StringsAreEqual_actualNull() {
			VerboseAsserts.StringsAreEqual( "check", null );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StringsAreEqual_notEquals() {
			VerboseAsserts.StringsAreEqual( "check", "check false" );
		}


		// Line Comparison methods ================================================

		[TestMethod]
		public void StringLinesAreEqual_arrays_success() {

			string[] first = { "one", "two" };
			string[] second = { "one", "two" };

			VerboseAsserts.StringLinesAreEqual(first, second);
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StringLinesAreEqual_arrays_failure() {

			string[] first = { "one", "two" };
			string[] second = { "one", "two", "three" };

			VerboseAsserts.StringLinesAreEqual(first, second);
		}

		[TestMethod]
		public void CompareStringLines_noIssue() {

			string[] first = { "one", "two" };
			string[] second = { "one", "two" };

			// invocation
			string result = VerboseAsserts.CompareStringLines(first, second);

			// assertions
			IsNull(result);
		}

		[TestMethod]
		public void CompareStringLines_expectIsLong() {

			string[] first = { "one", "two", "three" };
			string[] second = { "one", "two" };

			// invocation
			string result = VerboseAsserts.CompareStringLines(first, second);

			// assertions
			AreEqual("Strings do not match at line[2]\nOne space is larger than the other", result);
		}

		[TestMethod]
		public void CompareStringLines_actualIsLong() {

			string[] first = { "one", "two" };
			string[] second = { "one", "two", "three" };

			// invocation
			string result = VerboseAsserts.CompareStringLines(first, second);

			// assertions
			AreEqual("Strings do not match at line[2]\nOne space is larger than the other", result);
		}


		[TestMethod]
		public void FindLineDifference_noIssue() {

			string[] expect = { "same-1", "same-2" };
			string[] actual = { "same-1", "same-2" };

			// invocation
			var result = VerboseAsserts.FindLineDifference( expect, actual );

			// assertions
			IsNull( result );
		}

		[TestMethod]
		public void FindLineDifference_expectIsLong() {

			string[] expect = { "same-1", "same-2" };
			string[] actual = { "same-1" };

			// invocation
			var result = VerboseAsserts.FindLineDifference( expect, actual );

			// assertions
			AreEqual( 1, result.Line );
			AreEqual( 
				"Strings do not match at line[1]\n"+
				"One space is larger than the other", result.Complaint );
		}

		[TestMethod]
		public void FindLineDifference_actualIsLong() {

			string[] expect = { "same-1" };
			string[] actual = { "same-1", "same-2" };

			// invocation
			var result = VerboseAsserts.FindLineDifference( expect, actual );

			// assertions
			AreEqual( 1, result.Line );
			AreEqual( 
				"Strings do not match at line[1]\n"+
				"One space is larger than the other", result.Complaint );
		}

		[TestMethod]
		public void FindLineDifference_hasDiff() {
			string[] expect = { "same-1", "same-2" };
			string[] actual = { "same-1", "diff-2" };

			// invocation
			var result = VerboseAsserts.FindLineDifference( expect, actual );

			// assertions
			AreEqual( 1, result.Line );
			AreEqual( "Strings do not match at line [1]\n"+
				"[[same-2]]\n"+
				"[[diff-2]]", result.Complaint );
		}

		[TestMethod]
		public void DumpToConsole() {

			var console = ConsoleMocker.MockConsoleOut();

			try {
				string[] expect = { "test-1" };
				string[] actual = { "line-1" };

				// invocation
				VerboseAsserts.DumpToConsole( null, expect, actual );

				// assertions
				AreEqual( "[[\"line-1\"]]\n\n" , console.GetResult() );
			}
			finally {
				console.RestoreConsoleOut();
			}
		}

		[TestMethod]
		public void IssueToDisplay_nullIssue() {

			string[] expect = { "" };

			string actualBody = "{\n"+
						"  \"AChar\": \"X\",\n"+
						"  \"AnEnum\": \"One\",\n"+
						"  \"AnInt\": 123,\n"+
						"  \"AString\": \"some-value\"\n"+
						"}";
			string[] actual = actualBody.Split('\n');
			
			// invocation
			var result = VerboseAsserts.IssueToDisplay( null, expect, actual );

			// assertions :: formatted so result has one backslash on internal quotes
			//            :: which means that for 'expect/check' quotes are triple quoted
			var check = "[[\"{\\n\"+\n"+
				"\t\t\"  \\\"AChar\\\": \\\"X\\\",\\n\"+\n"+
				"\t\t\"  \\\"AnEnum\\\": \\\"One\\\",\\n\"+\n"+
				"\t\t\"  \\\"AnInt\\\": 123,\\n\"+\n"+
				"\t\t\"  \\\"AString\\\": \\\"some-value\\\"\\n\"+\n"+
				"\t\t\"}\"]]\n";

			AreEqual( check, result );
		}
		
		[TestMethod]
		public void IssueToDisplay_yesIssue() {

			string[] expect = { "" };

			string actualBody = "{\n"+
						"  \"AChar\": \"X\",\n"+
						"  \"AnEnum\": \"One\",\n"+
						"  \"AnInt\": 123,\n"+
						"  \"AString\": \"some-value\"\n"+
						"}";
			string[] actual = actualBody.Split('\n');

			VerboseAsserts.VerboseIssue issue = new VerboseAsserts.VerboseIssue(0,"some-issue");
			
			// invocation
			var result = VerboseAsserts.IssueToDisplay( issue, expect, actual );

			// assertions :: formatted so result has one backslash on internal quotes
			//            :: which means that the 'expect/check' quotes are triple quoted
			var check = "[[\"{\\n\"+\n"+
				"\t\t\"  \\\"AChar\\\": \\\"X\\\",\\n\"+\n"+
				"\t\t\"  \\\"AnEnum\\\": \\\"One\\\",\\n\"+\n"+
				"\t\t\"  \\\"AnInt\\\": 123,\\n\"+\n"+
				"\t\t\"  \\\"AString\\\": \\\"some-value\\\"\\n\"+\n"+
				"\t\t\"}\"]]\n"+
				"Issue: some-issue\n"+
				">>>>>>>> Differ At Line[0]\n"+
				"Expect: \n"+
				">>>>>>>>\n"+
				"Actual: {\n"+
				">>>>>>>>\n";

			AreEqual( check, result );
		}
	}
}
