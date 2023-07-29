// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using System.Collections;
using System.Collections.Generic;
using VerboseCSharp.Asserts;

namespace VerboseCSharpTests.Asserts {

	[TestClass]
	public class StringAssertsTest {

		[TestMethod]
		public void StartsWith_true() {
			StringAsserts.StartsWith( "check", "check true" );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StartsWith_false() {
			StringAsserts.StartsWith("check","false check");
		}

		[TestMethod]
		public void EndsWith() {
			StringAsserts.EndsWith( "check", "true check" );
		}
		
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void EndsWith_false() {
			StringAsserts.EndsWith("check","check false");
		}

		[TestMethod]
		public void Contains() {
			StringAsserts.Contains( "check", "true check true" );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void Contains_false() {
			StringAsserts.Contains( "check", "false false" );
		}

		[TestMethod]
		public void NotContains() {
			StringAsserts.NotContains( "check", "true true" );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void NotContains_false() {
			StringAsserts.NotContains( "check", "false check false" );
		}
		
		[TestMethod]
		public void IsEmpty() {
			StringAsserts.IsEmpty( (string)null );
			StringAsserts.IsEmpty( "" );
		}

		
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void Empty_false() {
			StringAsserts.IsEmpty( "false" );
		}

		[TestMethod]
		public void IsNotEmpty() {
			StringAsserts.IsNotEmpty("Hello");
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void IsNotEmpty_false_forNull() {
			StringAsserts.IsNotEmpty((string)null);
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void IsNotEmpty_false_forBlank() {
			StringAsserts.IsNotEmpty("");
		}

	}
}
