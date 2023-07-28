// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using VerboseCSharp.Asserts;
using VerboseCSharp.Utility;

using static VerboseCSharp.Asserts.VerboseAsserts;

namespace VerboseCSharpTests.Asserts {

	[TestClass]
	public class VerboseToolsTest {
		
		[TestMethod]
		public void GetProjectDirectory() {
			string value = VerboseTools.GetProjectDirectory();
			Assert.IsTrue( value.EndsWith("VerboseCSharpTests") );
		}

		[TestMethod]
		public void Print() {
			var mocker = ConsoleMocker.MockConsoleOut();
			try { 
				// invocation
				VerboseTools.Print("Hello World!");
				VerboseTools.Print("Testing");

				// assertion
				AreEqual("Hello World!\nTesting\n", mocker.GetResult());
			}
			finally {
				mocker.RestoreConsoleOut();
			}
		}

		[TestMethod]
		public void IsNullEquals_genericx() {

			IsTrue( VerboseTools.IsNullEquals<string>( null, null ) );
			IsTrue( VerboseTools.IsNullEquals<string>( "A", "A" ) );

			IsFalse( VerboseTools.IsNullEquals<string>( null, "A" ) );
			IsFalse( VerboseTools.IsNullEquals<string>( "A", null ) );
		}

	}

}
