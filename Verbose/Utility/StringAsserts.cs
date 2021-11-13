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
	public class StringAsserts {

		static public void StartsWith( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) VerboseFail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) VerboseFail("String is Null or Empty" );
			if (!actual.StartsWith(expect)) {
				VerboseFail("String does not start with expectation ["+actual+"]");
			}
		}

		static public void EndsWith( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) VerboseFail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) VerboseFail("String is Null or Empty" );
			if (!actual.EndsWith(expect)) {
				VerboseFail("String does not end with expectation ["+actual+"]");
			}
		}

		static public void Contains( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) VerboseFail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) VerboseFail("String is Null or Empty" );
			if (!actual.Contains(expect)) {
				VerboseFail("String does not contain expectation ["+actual+"]");
			}

		}

		static public void NotContains( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) VerboseFail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) VerboseFail("String is Null or Empty" );
			if (actual.Contains(expect)) {
				VerboseFail("String contains expectation ["+actual+"]");
			}
		}
		
		static public void Empty( string actual ) {
			if (!String.IsNullOrEmpty(actual)) {
				VerboseFail("String is not empty ["+actual+"]");
			}
		}

		static public void NotEmpty( string actual ) {
			if (String.IsNullOrEmpty(actual)) {
				VerboseFail("String is empty");
			}
		}

	}

}
