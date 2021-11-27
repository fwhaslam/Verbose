//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//

namespace Verbose.Utility {
	
	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using System.Collections.Generic;

	[TestClass]
	public class GenericCollectionAssertsTest {

		List<string> MakeList(params string[] args) {
			return new List<string>(args);
		}

//======================================================================================================================

		[TestMethod]
		public void IsEmpty() {

			List<string> list = new List<string>();

			GenericCollectionAsserts.IsEmpty( list );
		}
				
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void IsEmpty_false() {

			List<string> list = new List<string>();
			list.Add("hi");

			GenericCollectionAsserts.IsEmpty( list );
		}


		[TestMethod]
		public void IsNotEmpty() {

			List<string> list = new List<string>();
			list.Add("hi");

			GenericCollectionAsserts.IsNotEmpty( list );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void IsNotEmpty_false() {

			List<string> list = new List<string>();

			GenericCollectionAsserts.IsNotEmpty( list );
		}

		[TestMethod]
		public void IsFirst() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.IsFirst( "A" , list);

		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void IsFirst_false_empty() {
			
			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.IsFirst( null, list);

		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void IsFirst_false_outOfOrder() {
			
			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.IsFirst( "B", list);

		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void IsFirst_false_notAMember() {
			
			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.IsFirst( "D", list);

		}

		[TestMethod]
		public void IsLast() {
			
			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.IsLast( "C", list);

		}
		
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void IsLast_false_empty() {
			
			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.IsLast( null, list);

		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void IsLast_false_outOfOrder() {
			
			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.IsLast( "B", list);

		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void IsLast_false_notAMember() {
			
			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.IsLast( "D", list);
		}

//======================================================================================================================

		[TestMethod]
		public void StartsWith() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.StartsWith(MakeList( "A" ), list);
			GenericCollectionAsserts.StartsWith(MakeList( "A", "B" ), list);
			GenericCollectionAsserts.StartsWith(MakeList( "A", "B", "C"), list);
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StartsWith_false_empty() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.StartsWith(  MakeList( ), list);
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StartsWith_false_notStart() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.StartsWith( MakeList( "B" ), list);
		}
		
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StartsWith_false_atEnd() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.StartsWith( MakeList( "C" ), list);
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StartsWith_false_notAMember() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.StartsWith( MakeList( "D" ), list);
		}

//======================================================================================================================

		[TestMethod]
		public void EndsWith() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.EndsWith(MakeList( "C" ), list);
			GenericCollectionAsserts.EndsWith(MakeList( "B", "C" ), list);
			GenericCollectionAsserts.EndsWith(MakeList( "A", "B", "C"), list);
		}
		
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void EndsWith_false_empty() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.EndsWith( MakeList( ), list);
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void EndsWith_false_notEnd() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.EndsWith( MakeList( "B" ), list);
		}
		
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void EndsWith_false_atStart() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.EndsWith( MakeList( "A" ), list);
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void EndsWith_false_notAMember() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.EndsWith( MakeList( "D" ), list);
		}

//======================================================================================================================

		[TestMethod]
		public void Contains() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.Contains( MakeList( "A" ), list);
			GenericCollectionAsserts.Contains( MakeList( "B" ), list);
			GenericCollectionAsserts.Contains( MakeList( "C" ), list);

			GenericCollectionAsserts.Contains( MakeList( "A", "B" ), list);
			GenericCollectionAsserts.Contains( MakeList( "B", "C" ), list);

			GenericCollectionAsserts.Contains( MakeList( "A", "B", "C" ), list);

		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void Contains_false_empty() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.Contains( MakeList(), list);
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void Contains_false_notAMember() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.Contains( MakeList( "D" ), list);
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void Contains_false_outOfOrder() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.Contains( MakeList( "B", "A" ), list);
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void Contains_false_skippedMember() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.Contains( MakeList( "A", "C" ), list);
		}

//======================================================================================================================


		[TestMethod]
		public void NotContains() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( MakeList( "D" ), list);
			GenericCollectionAsserts.NotContains( MakeList( "B", "A" ), list);
			GenericCollectionAsserts.NotContains( MakeList( "A", "C" ), list);
		}
						
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_false_Empty() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( MakeList(), list);
		}
						
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_false_matchFirst() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( MakeList( "A" ), list);
		}
							
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_false_matchSecond() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( MakeList( "B" ), list);
		}

									
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_false_matchThird() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( MakeList( "C" ), list);
		}
							
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotNotContains_false_matchStart() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( MakeList( "A", "B" ), list);
		}
							
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_false_matchEnd() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( MakeList( "B", "C" ), list);
		}
							
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_false_matchAll() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( MakeList( "A", "B", "C" ), list);
		}

//======================================================================================================================


		[TestMethod]
		public void StartsWith_params() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.StartsWith(list, "A" );
			GenericCollectionAsserts.StartsWith(list, "A", "B" );
			GenericCollectionAsserts.StartsWith(list, "A", "B", "C" );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StartsWith_params_false_empty() {

			List<string> list = MakeList( "A", "B", "C" );
			string[] emptyList = { };

			GenericCollectionAsserts.StartsWith(list, emptyList );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StartsWith_params_false_notStart() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.StartsWith(list, "B" );
		}
		
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StartsWith_params_false_atEnd() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.StartsWith( list, "C" );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void StartsWith_params_false_notAMember() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.StartsWith( list, "D" );
		}

//======================================================================================================================

		[TestMethod]
		public void EndsWith_params() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.EndsWith( list, "C" );
			GenericCollectionAsserts.EndsWith( list, "B", "C" );
			GenericCollectionAsserts.EndsWith( list, "A", "B", "C" );
		}
		
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void EndsWith_params_false_empty() {

			List<string> list = MakeList( "A", "B", "C" );
			string[] emptyList = { };

			GenericCollectionAsserts.EndsWith( list , emptyList );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void EndsWith_params_false_notEnd() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.EndsWith( list, "B" );
		}
		
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void EndsWith_params_false_atStart() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.EndsWith( list, "A" );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void EndsWith_params_false_notAMember() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.EndsWith( list, "D" );
		}

//======================================================================================================================

		[TestMethod]
		public void Contains_params() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.Contains( list, "A" );
			GenericCollectionAsserts.Contains( list, "B" );
			GenericCollectionAsserts.Contains( list, "C" );

			GenericCollectionAsserts.Contains( list, "A", "B" );
			GenericCollectionAsserts.Contains( list, "B", "C" );

			GenericCollectionAsserts.Contains( list, "A", "B", "C" );

		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void Contains_params_false_empty() {

			List<string> list = MakeList( "A", "B", "C" );
			object[] emptyList = { };

			GenericCollectionAsserts.Contains( list, emptyList);
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void Contains_params_false_notAMember() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.Contains( list, "D" );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void Contains_params_false_outOfOrder() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.Contains( list, "B", "A" );
		}

		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void Contains_params_false_skippedMember() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.Contains( list, "A", "C" );
		}

//======================================================================================================================


		[TestMethod]
		public void NotContains_params() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( list, "D" );
			GenericCollectionAsserts.NotContains( list, "B", "A" );
			GenericCollectionAsserts.NotContains( list, "A", "C" );
		}
						
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_params_false_Empty() {

			List<string> list = MakeList( "A", "B", "C" );
			object[] emptyList = { };

			GenericCollectionAsserts.NotContains( list, emptyList );
		}
						
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_params_false_matchFirst() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( list, "A" );
		}
							
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_params_false_matchSecond() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( list, "B");
		}

									
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_params_false_matchThird() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( list, "C" );
		}
							
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotNotContains_params_false_matchStart() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( list, "A" ,"B" );
		}
							
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_params_false_matchEnd() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( list, "B", "C" );
		}
							
		[TestMethod]
		[ExpectedException(typeof(VerboseAssertionException))]
		public void  NotContains_params_false_matchAll() {

			List<string> list = MakeList( "A", "B", "C" );

			GenericCollectionAsserts.NotContains( list, "A", "B", "C" );
		}


	}
}
