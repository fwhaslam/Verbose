// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using static VerboseCSharp.Asserts.VerboseAsserts;

namespace VerboseCSharpTests.TestingFramework {

	[TestClass]
	public class YamlParserTest {
        
		[TestMethod]
		public void ToYamlString() {

			// preparation
			TestObjectOne work = new TestObjectOne();
			work.SomeString = "some-value";
			work.SomeInt = 123;
			work.SomeChar = 'X';
			work.SomeEnum = TestEnumOne.First;
			work.SomeList = new List<string>(){ "hi", "there" };

			// invocation
			var result = YamlParser.ToYamlString( work );

			// assertions
			StringsAreEqual(
				"SomeString: some-value\n"+
				"SomeInt: 123\n"+
				"SomeChar: X\n"+
				"SomeEnum: First\n"+
				"SomeList:\n"+
				"  - hi\n"+
				"  - there\n"+
				"", result );
		}

		[TestMethod]
		public void ToYamlString_zeroCharIssue() {

			TestObjectOne work = new TestObjectOne();

			// invocation
			var result = YamlParser.ToYamlString( work );

			// assertions
			StringsAreEqual(
				"SomeString: \n"+
				"SomeInt: 0\n"+
				"SomeChar: \"\\0\"\n"+
				"SomeEnum: First\n"+
				"SomeList: \n"+
				"", result );		
		}

    }
}
