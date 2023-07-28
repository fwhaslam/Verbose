// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using static VerboseCSharp.Asserts.VerboseAsserts;

namespace VerboseCSharpTests.TestingFramework {

	[TestClass]
	public class JsonParserTest {
        
		[TestMethod]
		public void ToJsonString() {

			// preparation
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
				"{\"SomeString\":\"some-value\",\"SomeInt\":123,\"SomeChar\":\"X\",\"SomeEnum\":0,\"SomeList\":[\"hi\",\"there\"]}" +
                "", result );
		}

		[TestMethod]
		public void ToJsonString_zeroCharIssue() {

			TestObjectOne work = new TestObjectOne();

			// invocation
			var result = JsonParser.ToJsonString( work );

			// assertions
			StringsAreEqual(
				"{\"SomeString\":null,\"SomeInt\":0,\"SomeChar\":\"\\u0000\",\"SomeEnum\":0,\"SomeList\":null}" +
                "", result );		
		}

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
				"{\"SomeString\":\"some-value\",\"SomeInt\":123,\"SomeChar\":\"X\",\"SomeEnum\":0,\"SomeList\":[\"hi\",\"there\"]}" +
                "", result );
		}

		
		[TestMethod]
		public void ToPrettyString() {

			TestObjectOne work = new TestObjectOne();
			work.SomeString = "some-value";
			work.SomeInt = 123;
			work.SomeChar = 'X';
			work.SomeEnum = TestEnumOne.First;
			work.SomeList = new List<string>(){ "hi","there" };

			// invocation
			var result = JsonParser.ToPrettyString( work );

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
				"}",  result );
		}
    }
}
