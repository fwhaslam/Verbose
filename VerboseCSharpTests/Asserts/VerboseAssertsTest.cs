// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using System.Collections;
using System.Collections.Generic;
using VerboseCSharp.Asserts;
using VerboseCSharp.Utility;

namespace VerboseCSharpTests.Asserts {

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
	}
}
