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
	public class VerboseAsserts {

		/// <summary>
		/// Provide extra information on how a string comparison has failed.
		/// </summary>
		/// <param name="expect"></param>
		/// <param name="actual"></param>
		static public void StringsAreEqual( string expect, string actual ) {

			if (expect==null && actual==null) return;
			if (expect==null)
				throw new AssertFailedException("Value is not null");
			if (actual==null)
				throw new AssertFailedException("Value is null");

			StringDiff diff = StringDiff.Compare( expect, actual );
			if (!diff.hasError()) return;

			// show check value
			Console.WriteLine( "Failed Expectation for Value [[ "+TestUtils.ToCodeString(diff.Actual)+" ]]");

			// display details
			if (diff.EDisplay!=null) { 
				Console.WriteLine( diff.EDisplay );
				Console.WriteLine( diff.Pointer );
				Console.WriteLine( diff.ADisplay );
			}
			
			// detailed exception
			throw new AssertFailedException( diff.Explain );
		}
				
	}

}
