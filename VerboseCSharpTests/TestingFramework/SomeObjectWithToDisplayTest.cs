// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using VerboseCSharp.Asserts;

namespace VerboseCSharpTests.TestingFramework {

    [TestClass]
    public class SomeObjectWithToDisplayTest {

        [TestMethod]
        public void _constructor(){

            // invocation
            var results = new SomeObjectWithToDisplay();

            // assertions
            VerboseAsserts.StringsAreEqual( 
                "SomeInt:0\n"+
                "SomeString:\n" +
                "", results.ToDisplay() );
        }

        [TestMethod]
        public void BuildOne_static(){

            // invocation
            var results = SomeObjectWithToDisplay.BuildOne();

            // assertions
            VerboseAsserts.StringsAreEqual( 
                "SomeInt:4\n"+
                "SomeString:hi\n" +
                "", results.ToDisplay() );
        }
        
        [TestMethod]
        public void DoubleIt(){

            var work = SomeObjectWithToDisplay.BuildOne();

            // invocation
            work.DoubleIt();

            // assertions
            VerboseAsserts.StringsAreEqual( 
                "SomeInt:8\n"+
                "SomeString:hihi\n" +
                "", work.ToDisplay() );
        }
    }
}
