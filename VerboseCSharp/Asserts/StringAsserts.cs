// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

namespace VerboseCSharp.Asserts {

	using System;
	using System.Collections;
	using System.Collections.Generic;

	using static VerboseCSharp.Utility.VerboseSupport;

	/// <summary>
	/// String and collection oriented assertions.  
	/// Provides common string and collection relations as assertions.
	/// </summary>
	public class StringAsserts {

		public static void StartsWith( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) VerboseFail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) VerboseFail("String is Null or Empty" );
			if (!actual.StartsWith(expect)) {
				VerboseFail("String does not start with expectation ["+actual+"]");
			}
		}

		public static void EndsWith( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) VerboseFail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) VerboseFail("String is Null or Empty" );
			if (!actual.EndsWith(expect)) {
				VerboseFail("String does not end with expectation ["+actual+"]");
			}
		}

		public static void Contains( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) VerboseFail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) VerboseFail("String is Null or Empty" );
			if (!actual.Contains(expect)) {
				VerboseFail("String does not contain expectation ["+actual+"]");
			}

		}

		public static void NotContains( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) VerboseFail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) VerboseFail("String is Null or Empty" );
			if (actual.Contains(expect)) {
				VerboseFail("String contains expectation ["+actual+"]");
			}
		}
		
		public static void IsEmpty( string actual ) {
			if (!String.IsNullOrEmpty(actual)) {
				VerboseFail("String is not empty ["+actual+"]");
			}
		}

		public static void IsNotEmpty( string actual ) {
			if (String.IsNullOrEmpty(actual)) {
				VerboseFail("String is empty");
			}
		}

	}

}
