//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//

namespace Verbose.Utility {

	using System;
	using System.Collections;
	using System.Collections.Generic;

	using static Verbose.Utility.VerboseSupport;

	/// <summary>
	/// String and collection oriented assertions.  
	/// Provides common string and collection relations as assertions.
	/// </summary>
	public class VerboseAsserts {

		/// <summary>
		/// Provide extra information on how a string comparison has failed.
		/// </summary>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		static public void StringsAreEqual( string expect, string actual ) {

			if (expect==null && actual==null) return;
			if (expect==null)
				VerboseFail("Value is not null");
			if (actual==null)
				VerboseFail("Value is null");

			StringDiff diff = StringDiff.Compare( expect, actual );
			if (!diff.hasError()) return;

			// show check value
			Console.WriteLine( "Failed Expectation for Value [[ "+ToCodeString(diff.Actual)+" ]]");

			// display details
			if (diff.EDisplay!=null) { 
				Console.WriteLine( diff.EDisplay );
				Console.WriteLine( diff.Pointer );
				Console.WriteLine( diff.ADisplay );
			}
			
			// detailed exception
			VerboseFail( diff.Explain );
		}
			
//		static public void StringLinesAreEqual( string[] expect, string[] actual ) {
//			string reason = CompareStringLines( expect, actual );
//			if (reason!=null) Fail( reason );
//		}

//		static public void StringLinesAreEqual( ICollection<string> expect, ICollection<string> actual ) {
//			string[] expectAry = expect.ToArray<string>();
//			string[] actualAry = actual.ToArray<string>();
//			StringLinesAreEqual( expectAry, actualAry );
//		}

//		static public void StringLinesAreEqual( string expect, string actual ) {

//			string[] expectAry = expect.Replace("\r","").Split( '\n' );
//			string[] actualAry = actual.Replace("\r","").Split( '\n' );
//			StringLinesAreEqual( expectAry, actualAry );
//		}

////======================================================================================================================

//		static internal string CompareStringLines( string[] expect, string[] actual ) {

//			DumpToConsole(actual);

//			int min = Math.Min(expect.Length,actual.Length);
//			int max = Math.Max(expect.Length,actual.Length);

//			for (int ix=0;ix<min;ix++) {
//				var first = expect[ix];
//				var second = actual[ix];
//				if (!first.Equals( second ) )
//						return "Strings do not match at line ["+ix+"]\n[["+first+"]]\n[["+second+"]]";
//			}

//			if (min<max) 
//				return "Strings do not match at line["+min+"]\nOne space is larger than the other";

//			return null;
//		}

//		static internal void DumpToConsole(string[] actual) {

//			var buf = new StringBuilder();

//			buf.Append( "[[\"" );
//			buf.Append( String.Join( "\\n\"+\n\t\t\"", actual ) );
//			buf.Append( "\"]]" );

//			Console.Out.WriteLine( buf.ToString() );
//		}
	
	}

}
