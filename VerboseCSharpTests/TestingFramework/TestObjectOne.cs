// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections.Generic;


namespace VerboseCSharpTests.TestingFramework {

	public enum TestEnumOne {
		First, Second
	};

	public class TestObjectOne {

		public string SomeString {  get; set; }
		public int SomeInt {  get; set; }
		public char SomeChar {  get; set; }
		public TestEnumOne SomeEnum { get; set; }
		public List<string> SomeList { get; set; }
	}

}
