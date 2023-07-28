// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerboseCSharp.Utility {
	
	public class VerboseIssue {
		internal int Line;
		internal string Complaint;
		internal VerboseIssue(int line,string complaint) {
			this.Line = line;
			this.Complaint = complaint;
		}
	}

    public class LineDiff {

		/// <summary>
		/// Locate Issue, Dump to Console, 
		/// </summary>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		/// <returns></returns>
		public static string CompareStringLines(string[] expect, string[] actual) {

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
		public static VerboseIssue FindLineDifference(string[] expect, string[] actual) {

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
		/// Dump Issue description to console.
		/// </summary>
		/// <param name="issue"></param>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		internal static void DumpToConsole(VerboseIssue issue, string[] expect, string[] actual) {

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
		internal static string IssueToDisplay(VerboseIssue issue, string[] expect, string[] actual) {

//Console.Out.WriteLine("START OF IssueToDisplay");
			var buf = new StringBuilder();

			// human readable display of 'actual'
			buf.Append("[[\"");
			for (int ax=0;ax<actual.Length;ax++) {
				if (ax>0) buf.Append("\\n\"+\n\t\t\"");
				buf.Append( FixQuoteSlashes( actual[ax] ) );
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


		/// <summary>
		/// Quotes may have multiple levels of slashes that need to be handled.
		/// </summary>
		/// <param name="work"></param>
		/// <returns></returns>
		internal static string FixQuoteSlashes( string work ) {
			return work.Replace("\\","\\\\").Replace("\"","\\\"");
		}

    }
}
