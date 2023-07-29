// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using VerboseCSharp.Asserts;
using VerboseCSharp.Utility;

using static VerboseCSharp.Asserts.VerboseAsserts;

namespace VerboseCSharpTests.Asserts {

	[TestClass]
	public class VerboseToolsTest {
		
		[TestMethod]
		public void GetProjectDirectory() {
			string value = VerboseTools.GetProjectDirectory();
			Assert.IsTrue( value.EndsWith("VerboseCSharpTests") );
		}

		[TestMethod]
		public void Print() {
			var mocker = ConsoleMocker.MockConsoleOut();
			try { 
				// invocation
				VerboseTools.Print("Hello World!");
				VerboseTools.Print("Testing");

				// assertion
				AreEqual("Hello World!\nTesting\n", mocker.GetResult());
			}
			finally {
				mocker.RestoreConsoleOut();
			}
		}

		[TestMethod]
		public void IsNullEquals_genericx() {

			IsTrue( VerboseTools.IsNullEquals<string>( null, null ) );
			IsTrue( VerboseTools.IsNullEquals<string>( "A", "A" ) );

			IsFalse( VerboseTools.IsNullEquals<string>( null, "A" ) );
			IsFalse( VerboseTools.IsNullEquals<string>( "A", null ) );
		}
			
		[TestMethod]
		public void GetDamerauLevenshteinDistance(){

			AreEqual( 0, VerboseTools.GetDamerauLevenshteinDistance( "same", "same" ) );
			AreEqual( 0, VerboseTools.GetDamerauLevenshteinDistance( "", "" ) );
			AreEqual( 0, VerboseTools.GetDamerauLevenshteinDistance( "Same\nOld", "Same\nOld" ) );

			AreEqual( 1, VerboseTools.GetDamerauLevenshteinDistance( "a", "A" ) );
			AreEqual( 1, VerboseTools.GetDamerauLevenshteinDistance( "a", "" ) );
			AreEqual( 1, VerboseTools.GetDamerauLevenshteinDistance( "a", "b" ) );
			AreEqual( 1, VerboseTools.GetDamerauLevenshteinDistance( "a", "ab" ) );

			AreEqual( 1, VerboseTools.GetDamerauLevenshteinDistance( "ba", "ab" ) );

		}

		[TestMethod]
		public void GetDamerauLevenshteinDistance_longStrings(){

			var first = "something sort of long that has some similarity to the next";
			var second = "something that is sort fo long with some kind of similarity to the previous";

			var results = VerboseTools.GetDamerauLevenshteinDistance( first,second );

			AreEqual( 30, results );
		}

		[TestMethod]
		public void GetSimilarityRating(){

			AreEqual( 1f, VerboseTools.GetSimilarityRating( "", "" ) );
			AreEqual( 1f, VerboseTools.GetSimilarityRating( "a", "a" ) );
			AreEqual( 0f, VerboseTools.GetSimilarityRating( "a", "b" ) );
			AreEqual( 0.5f, VerboseTools.GetSimilarityRating( "a", "ab" ) );
			
		}
	}

}
