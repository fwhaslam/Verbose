// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using System;
using System.Collections.Generic;
using System.Text;

using DiffPlex.DiffBuilder;
using DiffPlex.DiffBuilder.Model;

using static VerboseCSharp.Asserts.VerboseAsserts;
using static VerboseCSharp.Utility.VerboseTools;

namespace VerboseCSharpTests.TestingFramework {

	[TestClass]
	public class JsonParserTest {

		[TestMethod]
		public void ToJsonString_object() {

			TestObjectOne work = new TestObjectOne();
			work.SomeString = "some-value";
			work.SomeInt = 123;
			work.SomeChar = 'X';
			work.SomeEnum = TestEnumOne.First ;
			work.SomeList = new List<string>(){ "hi","there" };

			// invocation
			var result = JsonParser.ToJsonString( work );

			// assertions
			StringsAreEqual(
				"{\n"+
				"  \"SomeChar\": \"X\",\n"+
				"  \"SomeEnum\": \"First\",\n"+
				"  \"SomeInt\": 123,\n"+
				"  \"SomeList\": [\n"+
				"    \"hi\",\n"+
				"    \"there\"\n"+
				"  ],\n"+
				"  \"SomeString\": \"some-value\"\n"+
				"}", result );
		}
		
		[TestMethod]
		public void ToJsonString_zeroCharIssue() {

			TestObjectOne work = new TestObjectOne();

			// invocation
			var result = JsonParser.ToJsonString( work );

			// assertions
			StringsAreEqual(
				"{\n"+
				"  \"SomeChar\": \"\\u0000\",\n"+
				"  \"SomeEnum\": \"First\",\n"+
				"  \"SomeInt\": 0,\n"+
				"  \"SomeList\": null,\n"+
				"  \"SomeString\": null\n"+
				"}", result );		
		}
    }
}
