// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using static VerboseCSharp.Utility.LineDiff;

namespace VerboseCSharp.Asserts {


	using static VerboseCSharp.Utility.VerboseSupport;

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

	}

}
