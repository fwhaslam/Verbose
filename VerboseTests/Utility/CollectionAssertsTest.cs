

namespace Verbose.Utility {

	using Microsoft.VisualStudio.TestTools.UnitTesting;
	using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

	using System.Collections;
	using System.Collections.Generic;
	using System;

	[TestClass]
	public class CollectionAssertsTest {

		List<string> MakeList(params string[] args) {
			return new List<string>(args);
		}

//======================================================================================================================

		[TestMethod]
		public void StartsWith() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.StartsWith(MakeList( "A" ), list);
			CollectionAsserts.StartsWith(MakeList( "A", "B" ), list);
			CollectionAsserts.StartsWith(MakeList( "A", "B", "C"), list);
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void StartsWith_false_empty() {

			List<string> list = MakeList( "A", "B", "C" );
			List<string> emptyList = MakeList( );

			CollectionAsserts.StartsWith(emptyList, list);
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void StartsWith_false_notStart() {

			List<string> list = MakeList( "A", "B", "C" );
			List<string> emptyList = MakeList( "B" );

			CollectionAsserts.StartsWith(emptyList, list);
		}
		
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void StartsWith_false_atEnd() {

			List<string> list = MakeList( "A", "B", "C" );
			List<string> emptyList = MakeList( "C" );

			CollectionAsserts.StartsWith(emptyList, list);
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void StartsWith_false_notAMember() {

			List<string> list = MakeList( "A", "B", "C" );
			List<string> emptyList = MakeList( "D" );

			CollectionAsserts.StartsWith(emptyList, list);
		}

//======================================================================================================================

		[TestMethod]
		public void EndsWith() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.EndsWith(MakeList( "C" ), list);
			CollectionAsserts.EndsWith(MakeList( "B", "C" ), list);
			CollectionAsserts.EndsWith(MakeList( "A", "B", "C"), list);
		}
		
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void EndsWith_false_empty() {

			List<string> list = MakeList( "A", "B", "C" );
			List<string> emptyList = MakeList( );

			CollectionAsserts.EndsWith(emptyList, list);
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void EndsWith_false_notEnd() {

			List<string> list = MakeList( "A", "B", "C" );
			List<string> emptyList = MakeList( "B" );

			CollectionAsserts.EndsWith(emptyList, list);
		}
		
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void EndsWith_false_atStart() {

			List<string> list = MakeList( "A", "B", "C" );
			List<string> emptyList = MakeList( "A" );

			CollectionAsserts.EndsWith(emptyList, list);
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void EndsWith_false_notAMember() {

			List<string> list = MakeList( "A", "B", "C" );
			List<string> emptyList = MakeList( "D" );

			CollectionAsserts.EndsWith(emptyList, list);
		}

//======================================================================================================================

		[TestMethod]
		public void Contains() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.Contains( MakeList( "A" ), list);
			CollectionAsserts.Contains( MakeList( "B" ), list);
			CollectionAsserts.Contains( MakeList( "C" ), list);

			CollectionAsserts.Contains( MakeList( "A", "B" ), list);
			CollectionAsserts.Contains( MakeList( "B", "C" ), list);

			CollectionAsserts.Contains( MakeList( "A", "B", "C" ), list);

		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void Contains_false_empty() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.Contains( MakeList(), list);
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void Contains_false_notAMember() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.Contains( MakeList( "D" ), list);
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void Contains_false_outOfOrder() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.Contains( MakeList( "B", "A" ), list);
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void Contains_false_skippedMember() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.Contains( MakeList( "A", "C" ), list);
		}

//======================================================================================================================


		[TestMethod]
		public void NotContains() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.NotContains( MakeList( "D" ), list);
			CollectionAsserts.NotContains( MakeList( "B", "A" ), list);
			CollectionAsserts.NotContains( MakeList( "A", "C" ), list);
		}
						
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void  NotContains_false_Empty() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.NotContains( MakeList(), list);
		}
						
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void  NotContains_false_matchFirst() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.NotContains( MakeList( "A" ), list);
		}
							
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void  NotContains_false_matchSecond() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.NotContains( MakeList( "B" ), list);
		}

									
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void  NotContains_false_matchThird() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.NotContains( MakeList( "C" ), list);
		}
							
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void  NotNotContains_false_matchStart() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.NotContains( MakeList( "A", "B" ), list);
		}
							
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void  NotContains_false_matchEnd() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.NotContains( MakeList( "B", "C" ), list);
		}
							
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void  NotContains_false_matchAll() {

			List<string> list = MakeList( "A", "B", "C" );

			CollectionAsserts.NotContains( MakeList( "A", "B", "C" ), list);
		}

//======================================================================================================================

		[TestMethod]
		public void Empty() {

			List<string> list = new List<string>();

			CollectionAsserts.Empty( list );
		}
				
		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void Empty_false() {

			List<string> list = new List<string>();
			list.Add("hi");

			CollectionAsserts.Empty( list );
		}


		[TestMethod]
		public void NotEmpty() {

			List<string> list = new List<string>();
			list.Add("hi");

			CollectionAsserts.NotEmpty( list );
		}

		[TestMethod]
		[ExpectedException(typeof(AssertFailedException))]
		public void NotEmpty_false() {

			List<string> list = new List<string>();

			CollectionAsserts.NotEmpty( list );
		}

//======================================================================================================================

		[TestMethod]
		public void StartWith_params() {
			Fail("write me");
		}

		[TestMethod]
		public void EndsWith_params() {
			Fail("write me");
		}

		[TestMethod]
		public void Contains_params() {
			Fail("write me");
		}

		[TestMethod]
		public void NotContains_params() {
			Fail("write me");
		}

	}
}
