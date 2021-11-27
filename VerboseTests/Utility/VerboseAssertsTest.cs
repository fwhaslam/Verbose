//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//

namespace Verbose.Utility {

	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

	using System.Collections;
	using System.Collections.Generic;

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

	
		//[TestMethod]
		//public void StringLinesAreEqual_arrays_success() {

		//	string[] first = {"one","two" };
		//	string[] second = {"one","two"};

		//	VerboseAsserts.StringsAreEqual( first, second );
		//}

		//[TestMethod]
		//[ExpectedException(typeof(AssertFailedException))]
		//public void StringLinesAreEqual_arrays_failure() {

		//	string[] first = {"one","two" };
		//	string[] second = {"one","two", "three" };

		//	VerboseAsserts.StringsAreEqual( first, second );
		//}

		//[TestMethod]
		//public void CompareStringLines_success() {

		//	string[] first = {"one","two" };
		//	string[] second = {"one","two"};

		//	// invocation
		//	string result = CompareStringLines( first, second );

		//	// assertions
		//	IsNull( result );
		//}

		//[TestMethod]
		//public void CompareStringLines_fail_forExpectLength() {

		//	string[] first = {"one","two", "three" };
		//	string[] second = {"one","two" };

		//	// invocation
		//	string result = CompareStringLines( first, second );

		//	// assertions
		//	AreEqual( "Strings do not match at line[2]\nOne space is larger than the other", result );
		//}
	}
}
