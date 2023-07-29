// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VerboseCSharp.Utility;

using static VerboseCSharp.Utility.VerboseSupport;

namespace VerboseCSharp.Asserts {


	/// <summary>
	/// String and collection oriented assertions.  
	/// Provides common string and collection relations as assertions.
	/// </summary>
	public class VerboseAsserts {

		/// <summary>
		/// Wrapper over line by line comparison of strings.
		/// </summary>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		public static void StringsAreEqual( string expect, string actual ) {

			// check for null comparisons
			if (expect == null && actual == null) return;
			if (expect == null)
				VerboseFail("Actual value is not null.");
			if (actual == null)
				VerboseFail("Actual value is null.");

			// evaluate
			var (summary,copy,report) = AnalyzeWithDiffPlex.CompareStrings(expect, actual);

			// no difference, no output
			if (summary==null) return;

			// display copy+paste value, display detailed report
			Console.Out.WriteLine( "Actual Value For Copy and Paste "+copy );

			Console.Out.WriteLine(
				"\n:::: Detailed Line Difference Report ::::\n"+
				report+
				"\n:::: End of Report ::::");

			// throw summary
			throw new VerboseAssertionException(summary);
		}

	}

}
