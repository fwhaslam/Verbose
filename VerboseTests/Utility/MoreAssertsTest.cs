using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using System.Collections;
using System.Collections.Generic;

namespace Verbose.Utility {

	[TestClass]
	public class MoreAssertsTest {

		[TestMethod]
		public void StringsAreEqual_success() {
			MoreAsserts.StringsAreEqual( "check", "check" );
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void StringsAreEqual_expectNull() {
			MoreAsserts.StringsAreEqual( null, "check" );
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void StringsAreEqual_actualNull() {
			MoreAsserts.StringsAreEqual( "check", null );
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void StringsAreEqual_notEquals() {
			MoreAsserts.StringsAreEqual( "check", "check false" );
		}
		
		// strings
		//=====================

		[TestMethod]
		public void StartsWith_true() {
			MoreAsserts.StartsWith( "check", "check true" );
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void StartsWith_false() {
			MoreAsserts.StartsWith("check","false check");
		}

		[TestMethod]
		public void EndsWith() {
			MoreAsserts.EndsWith( "check", "true check" );
		}
		
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void EndsWith_false() {
			MoreAsserts.EndsWith("check","check false");
		}

		[TestMethod]
		public void Contains() {
			MoreAsserts.Contains( "check", "true check true" );
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void Contains_false() {
			MoreAsserts.Contains( "check", "false false" );
		}

		[TestMethod]
		public void NotContains() {
			MoreAsserts.NotContains( "check", "true true" );
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void NotContains_false() {
			MoreAsserts.NotContains( "check", "false check false" );
		}
		
		[TestMethod]
		public void Empty() {
			MoreAsserts.Empty( (string)null );
			MoreAsserts.Empty( "" );
		}

		[TestMethod]
		public void NotEmpty() {
			Assert.Fail("write me");
		}
		
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void Empty_false() {
			MoreAsserts.Empty( "false" );
		}

		// collections
		//=====================
		
		[TestMethod]
		public void StartsWith_collection() {
			Assert.Fail("write me");
		}

		[TestMethod]
		public void EndsWith_collection() {
			Assert.Fail("write me");
		}

		[TestMethod]
		public void Contains_collection() {
			Assert.Fail("write me");
		}

		[TestMethod]
		public void NotContains_collection() {
			Assert.Fail("write me");
		}
				
		[TestMethod]
		public void Empty_collection() {
			Assert.Fail("write me");
		}

		[TestMethod]
		public void NotEmpty_collection() {
			Assert.Fail("write me");
		}

		// generic collections
		//=====================

		[TestMethod]
		public void StartsWith_generic() {
			Assert.Fail("write me");
		}

		[TestMethod]
		public void EndsWith_generic() {
			Assert.Fail("write me");
		}

		[TestMethod]
		public void Contains_generic() {
			Assert.Fail("write me");
		}

		[TestMethod]
		public void NotContains_generic() {
			Assert.Fail("write me");
		}
		
		[TestMethod]
		public void Empty_generic() {
			Assert.Fail("write me");
		}

		[TestMethod]
		public void NotEmpty_generic() {
			Assert.Fail("write me");
		}

	}
}
