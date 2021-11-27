//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Text;

namespace Verbose.Utility {

	[TestClass]
	public class StringDiffTest {

		[TestMethod]
		public void _constructor() {

			// invocation
			var result = new StringDiff();

			/// assertion
			VerboseAsserts.StringsAreEqual( "{\n"+
				"  \"Actual\": null,\n"+
				"  \"ADisplay\": null,\n"+
				"  \"Cut\": 0,\n"+
				"  \"Diff\": 0,\n"+
				"  \"EDisplay\": null,\n"+
				"  \"Expect\": null,\n"+
				"  \"Explain\": null,\n"+
				"  \"Pointer\": null,\n"+
				"  \"Row\": 0\n"+
				"}", VerboseTools.AsPrettyString( result ) );
		}
	}
}
