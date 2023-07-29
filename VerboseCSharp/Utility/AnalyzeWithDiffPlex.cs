// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

namespace VerboseCSharp.Utility {

    public class AnalyzeWithDiffPlex {

		internal static float SIMILARITY_THRESHOLD = 0.3f;

        /// <summary>
		/// Find differences with DiffPlex.
        /// Print: Summary, Copyable String, and Report.
		/// </summary>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		/// <returns>(summary,copyable,report) = with summary/report==null means no differences.</returns>
		public static (string,string,string) CompareStrings(string expect, string actual) {

			// summary values
			int addSum=0, rmvSum=0, modSum=0;

			// build copy and report lists
			var copyList = new List<string>();
			var reportList = new List<(string,string)>();

			var diff = InlineDiffBuilder.Diff( expect, actual );
			var lines = diff.Lines;

            for (int ix = 0; ix < lines.Count; ix++) {

                var line = lines[ix];
				var type = line.Type;
				var text = line.Text;

				// same as it ever was
                if (type == ChangeType.Unchanged) {
                    copyList.Add(text);
					reportList.Add( ("   ", text ) );
					continue;
                }
               
				// new lines
				if (type == ChangeType.Inserted) {
					addSum++;
					copyList.Add(text);
					reportList.Add( ("+>>", text ) );

					// check for 'modified' condition
					if (ix>0 && lines[ix-1].Type==ChangeType.Deleted) {
						if (IsSimilar( text, lines[ix-1].Text ) ) {

							rmvSum--;
							addSum--;
							modSum++;

							reportList[ix-1] = ( "old", lines[ix-1].Text );
							reportList[ix] = ( "new", text );
						}
					}
					continue;
                }
                
				// removals
				if (type == ChangeType.Deleted) {
					rmvSum++;
					reportList.Add( ("<<-", text ) );
					continue;
                }

				// default - wa'happen?
				throw new SystemException("Unexpected ChangeType=["+type+"]");
            }

			var copyString = ToCopy( copyList );
			var reportString = ToReport( reportList );
			var summary = ( !diff.HasDifferences ? null : ToSummary(addSum, rmvSum, modSum ) );

			return ( summary, copyString, reportString );
		}

		internal static bool IsSimilar( string first, string second ){
			return VerboseTools.GetSimilarityRating(first,second) >= SIMILARITY_THRESHOLD;
		}

		internal static string ToSummary( int addSum, int rmvSum, int modSum ) {
			var parts = new List<string>();
			if (addSum>0) parts.Add( "added="+addSum );
			if (rmvSum>0) parts.Add( "removed="+rmvSum );
			if (modSum>0) parts.Add( "modified="+modSum );
			return "Lines Different ("+ string.Join(", ",parts)+") see report for details.";
		}

		internal static string ToReport( List<(string,string)> reportList ) {
			return string.Join("\n", reportList.Select( (r) => r.Item1+": "+r.Item2 ) );
		}

		/// <summary>
        /// Copy and Paste value for Actual input.
        /// </summary>
        /// <param name="actual"></param>
        /// <returns></returns>
		internal static string ToCopy( List<string> actual ) {

			// human readable display of 'actual'
			var buf = new StringBuilder();

			buf.Append("[[\"");
			for (int ax=0;ax<actual.Count;ax++) {
				if (ax>0) buf.Append("\\n\"+\n\t\t\"");
				buf.Append( FixQuoteSlashes( actual[ax] ) );
//Console.Out.WriteLine( "["+ax+"/"+actual[ax].Length+"] "+actual[ax]);
			}
			buf.Append("\"]]");

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
