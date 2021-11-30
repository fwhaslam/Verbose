//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//

namespace Verbose.Utility {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;

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
		//static public void StringsAreEqual( string expect, string actual ) {

		//	if (expect==null && actual==null) return;
		//	if (expect==null)
		//		VerboseFail("Value is not null");
		//	if (actual==null)
		//		VerboseFail("Value is null");

		//	StringDiff diff = StringDiff.Compare( expect, actual );
		//	if (!diff.hasError()) return;

		//	// show check value
		//	Console.WriteLine( "Failed Expectation for Value [[ "+ToCodeString(diff.Actual)+" ]]");

		//	// display details
		//	if (diff.EDisplay!=null) { 
		//		Console.WriteLine( diff.EDisplay );
		//		Console.WriteLine( diff.Pointer );
		//		Console.WriteLine( diff.ADisplay );
		//	}
			
		//	// detailed exception
		//	VerboseFail( diff.Explain );
		//}

		/// <summary>
		/// Wrapper over line by line comparison of strings.
		/// </summary>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		static public void StringsAreEqual( string expect, string actual ) {
			if (expect == null && actual == null) return;
			if (expect == null)
				VerboseFail("Actual value is not null.");
			if (actual == null)
				VerboseFail("Actual value is null.");
			StringLinesAreEqual( expect, actual );
		}

		static public void StringLinesAreEqual(string[] expect, string[] actual) {
			string reason = CompareStringLines(expect, actual);
			if (reason != null) throw new VerboseAssertionException(reason);
		}

		static public void StringLinesAreEqual(ICollection<string> expect, ICollection<string> actual) {
			string[] expectAry = expect.ToArray<string>();
			string[] actualAry = actual.ToArray<string>();
			StringLinesAreEqual(expectAry, actualAry);
		}

		static public void StringLinesAreEqual(string expect, string actual) {

			string[] expectAry = expect.Replace("\r", "").Split('\n');
			string[] actualAry = actual.Replace("\r", "").Split('\n');
			StringLinesAreEqual(expectAry, actualAry);
		}

//======================================================================================================================

		internal class VerboseIssue {
			internal int Line;
			internal string Complaint;
			internal VerboseIssue(int line,string complaint) {
				this.Line = line;
				this.Complaint = complaint;
			}
		}

		/// <summary>
		/// Locate Issue, Dump to Console, 
		/// </summary>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		/// <returns></returns>
		static internal string CompareStringLines(string[] expect, string[] actual) {

			var issue = FindLineDifference( expect, actual );

			Console.Out.WriteLine( IssueToDisplay( issue, expect, actual ) );

			return ( issue==null ? null : issue.Complaint );
		}

		/// <summary>
		/// Identify and locate first issue.
		/// </summary>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		/// <returns></returns>
		static internal VerboseIssue FindLineDifference(string[] expect, string[] actual) {

			int min = Math.Min(expect.Length, actual.Length);
			int max = Math.Max(expect.Length, actual.Length);

			for (int ix = 0; ix < min; ix++) {
				var first = expect[ix];
				var second = actual[ix];
				if (!first.Equals(second)) {
					return new VerboseIssue( 
						ix, 
						"Strings do not match at line [" + ix + "]\n[[" + first + "]]\n[[" + second + "]]" );
				}
			}

			if (min < max) {
				return new VerboseIssue(
					min, 
					"Strings do not match at line[" + min + "]\nOne space is larger than the other" );
			}

			return null;
		}

		/// <summary>
		/// Dump Issue descript to console.
		/// </summary>
		/// <param name="issue"></param>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		static internal void DumpToConsole(VerboseIssue issue, string[] expect, string[] actual) {

			var msg = IssueToDisplay( issue, expect, actual );

			Console.Out.WriteLine( msg );
		}

		/// <summary>
		/// Explain issue for the humans.
		/// </summary>
		/// <param name="issue"></param>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		/// <returns></returns>
		static internal string IssueToDisplay(VerboseIssue issue, string[] expect, string[] actual) {

//Console.Out.WriteLine("START OF IssueToDisplay");
			var buf = new StringBuilder();

			// human readable display of 'actual'
			buf.Append("[[\"");
			for (int ax=0;ax<actual.Length;ax++) {
				if (ax>0) buf.Append("\\n\"+\n\t\t\"");
				buf.Append( actual[ax].Replace( "\"", "\\\"" ) );
//Console.Out.WriteLine( "["+ax+"/"+actual[ax].Length+"] "+actual[ax]);
			}
			buf.Append("\"]]\n");

			// explain and demonstrate issue
			if ( issue!=null ) {
				var line = issue.Line;
				buf.Append("Issue: "+issue.Complaint );
				buf.Append("\n>>>>>>>> Differ At Line[").Append(line).Append("]\nExpect: ");

				if (line>=expect.Length) buf.Append("*OutOfBounds*");
				else buf.Append( expect[line] );

				buf.Append("\n>>>>>>>>\nActual: ");

				if (line>=actual.Length)  buf.Append("*OutOfBounds*");
				else buf.Append( actual[line] );

				buf.Append("\n>>>>>>>>\n");
			}

			return buf.ToString();
		}

	}

}
