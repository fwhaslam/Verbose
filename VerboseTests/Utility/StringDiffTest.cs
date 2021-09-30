using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections.Generic;
using System.Text;

namespace Verbose.Utility {

	[TestClass]
	class StringDiffTest {

		[TestMethod]
		public void _constructor() {

			// invocation
			var result = new StringDiff();

			/// assertion
			MoreAsserts.StringsAreEqual( "", TestUtils.AsPrettyString( result ) );
		}
	}
}
