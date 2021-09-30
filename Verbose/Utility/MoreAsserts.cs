using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections;
using System.Collections.Generic;

using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace Verbose.Utility {

	public class MoreAsserts {

		/// <summary>
		/// Provide extra information on how a string comparison has failed.
		/// </summary>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		static public void StringsAreEqual( string expect, string actual ) {

			if (expect==null && actual==null) return;
			if (expect==null)
				throw new AssertFailedException("Value is not null");
			if (actual==null)
				throw new AssertFailedException("Value is null");

			StringDiff diff = StringDiff.Compare( expect, actual );
			if (!diff.hasError()) return;

			// show check value
			Console.WriteLine( "Failed Expectation for Value [[ "+TestUtils.ToCodeString(diff.Actual)+" ]]");

			// display details
			if (diff.EDisplay!=null) { 
				Console.WriteLine( diff.EDisplay );
				Console.WriteLine( diff.Pointer );
				Console.WriteLine( diff.ADisplay );
			}
			
			// detailed exception
			throw new AssertFailedException( diff.Explain );
		}
				
		// strings
		//=====================

		static public void StartsWith( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) Fail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) Fail("String is Null or Empty" );
			if (!actual.StartsWith(expect)) Fail("String does not start with expectation ["+actual+"]");
		}

		static public void EndsWith( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) Fail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) Fail("String is Null or Empty" );
			if (!actual.EndsWith(expect)) Fail("String does not end with expectation ["+actual+"]");
		}

		static public void Contains( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) Fail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) Fail("String is Null or Empty" );
			if (!actual.Contains(expect)) Fail("String does not contain expectation ["+actual+"]");

		}

		static public void NotContains( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) Fail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) Fail("String is Null or Empty" );
			if (actual.Contains(expect)) Fail("String contains expectation ["+actual+"]");
		}
		
		static public void Empty( string actual ) {
			if (!String.IsNullOrEmpty(actual)) Fail("String is not empty ["+actual+"]");
		}

		static public void NotEmpty( string actual ) {
			if (String.IsNullOrEmpty(actual)) Fail("String is empty");
		}

		// collections
		//=====================
		
		static public void StartsWith( object expect, ICollection actual ) {
			Assert.Fail("write me");
		}

		static public void EndsWith( object expect, ICollection actual ) {
			Assert.Fail("write me");
		}

		[TestMethod]
		static public void Contains( object expect, ICollection actual ) {
			Assert.Fail("write me");
		}

		static public void NotContains( object expect, ICollection actual ) {
			Assert.Fail("write me");
		}
		
		static public void Empty( ICollection actual ) {
			Assert.Fail("write me");
		}

		static public void NotEmpty( ICollection actual ) {
			Assert.Fail("write me");
		}

		// generic collections
		//=====================

		static public void StartsWith<T>( T expect, ICollection<T> actual ) {
			Assert.Fail("write me");
		}

		static public void EndsWith<T>( T expect, ICollection<T> actual ) {
			Assert.Fail("write me");
		}

		static public void Contains<T>( T expect, ICollection<T> actual ) {
			Assert.Fail("write me");
		}

		static public void NotContains<T>( T expect, ICollection<T> actual ) {
			Assert.Fail("write me");
		}
		
		static public void Empty<T>( ICollection<T> actual ) {
			Assert.Fail("write me");
		}

		static public void NotEmpty<T>( ICollection<T> actual ) {
			Assert.Fail("write me");
		}

	}

}
