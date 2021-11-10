using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections;
using System.Collections.Generic;

using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace Verbose.Utility {

	/// <summary>
	/// String and collection oriented assertions.  
	/// Provides common string and collection relations as assertions.
	/// </summary>
	public class StringAsserts {

		static public void StartsWith( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) Fail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) Fail("String is Null or Empty" );
			if (!actual.StartsWith(expect)) {
				Fail("String does not start with expectation ["+actual+"]");
			}
		}

		static public void EndsWith( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) Fail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) Fail("String is Null or Empty" );
			if (!actual.EndsWith(expect)) {
				Fail("String does not end with expectation ["+actual+"]");
			}
		}

		static public void Contains( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) Fail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) Fail("String is Null or Empty" );
			if (!actual.Contains(expect)) {
				Fail("String does not contain expectation ["+actual+"]");
			}

		}

		static public void NotContains( string expect, string actual ) {
			if (String.IsNullOrEmpty(expect)) Fail("Cannot expect null or empty string");
			if (String.IsNullOrEmpty(actual)) Fail("String is Null or Empty" );
			if (actual.Contains(expect)) {
				Fail("String contains expectation ["+actual+"]");
			}
		}
		
		static public void Empty( string actual ) {
			if (!String.IsNullOrEmpty(actual)) {
				Fail("String is not empty ["+actual+"]");
			}
		}

		static public void NotEmpty( string actual ) {
			if (String.IsNullOrEmpty(actual)) {
				Fail("String is empty");
			}
		}

	}

}
