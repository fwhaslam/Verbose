//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//

using System;

namespace Verbose.Utility {

	/// <summary>
	/// Static method to compare strings returns a StringDiff object
	/// with detailed explanation of the first difference found.
	/// </summary>
	[Obsolete("VerboseAsserts.StringsAreEqual() is now supported by VeboseAsserts.FindLineDifference()")]
	public class StringDiff {

		public bool hasError() { return Explain!=null; }

		public string Expect { get; set; }
		public string Actual { get; set; }
		public string EDisplay { get; set; }
		public string ADisplay { get; set; }
		public string Pointer { get; set; }
		public string Explain { get; set; }

		public int Diff { get; set; }
		public int Row {  get; set; }
		public int Cut {  get; set; }

		/// <summary>
		/// Construct a StringDiff object with explanation of the 
		/// first difference between the target strings.
		/// </summary>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		/// <returns></returns>
		static public StringDiff Compare( string expect, string actual ) {
			
			StringDiff diff = new StringDiff();
			if (expect.Equals(actual)) return diff;

			diff.Analyze( expect, actual );
			return diff;
		}

		internal void Analyze( string expect, string actual ) {

			Expect = expect;
			Actual = actual;

			char[] echars = expect.ToCharArray();
			char[] achars = actual.ToCharArray();
			int limit = Math.Min( echars.Length, achars.Length );

			// find difference
			Row=0;
			for (Diff=0;Diff<limit;Diff++) {
				if (echars[Diff]!=achars[Diff]) break;
				if (echars[Diff]=='\n') {
					Row++;
					Cut = Diff+1;
				}
			}

			// show check value
			//Console.WriteLine( "Failed Expectation for Value [[ "+TestUtils.ToCodeString(actual)+" ]]");

			// length exception
			if (Diff==limit) {
				Explain = "Strings differ in length <"+echars.Length+"/"+achars.Length+
					"> see additional output for details.";
				return;
			}

			// show line with difference
			int enext = EndOfSegment( echars, Cut, '\n' );
			EDisplay = "\t>>>> "+expect.Substring( Cut, enext-Cut );
			int anext = EndOfSegment( achars, Cut, '\n' );
			ADisplay =  "\t>>>> "+actual.Substring( Cut, anext-Cut );
			Pointer = "\t>>>> "+ new string(' ',Diff-Cut) + "^";

			//Console.WriteLine( edisplay );
			//Console.WriteLine( pointer );
			//Console.WriteLine( adisplay );
			
			// detailed exception
			string charDiff = "ascii(exp/act)["+(int)echars[Diff]+"]["+(int)achars[Diff]+"]";
			if (echars[Diff]>=32 && achars[Diff]>=32) {
				charDiff += "=["+echars[Diff]+"/"+achars[Diff]+"]";
			}

			Explain = 
				"Strings differ at position ["+Diff+"] " +
				"line/char["+Row+"/"+(Diff-Cut)+"] " +
				charDiff+
				" see additional output for details.";
		}
		
		static internal int EndOfSegment( char[] work, int cut, char find ) {
			for (int ix=1+cut;ix<work.Length;ix++) {
				if (work[ix]==find) return ix-1;
			}
			return work.Length;
		}
	}

}
