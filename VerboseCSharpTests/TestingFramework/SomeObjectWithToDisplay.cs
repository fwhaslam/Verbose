// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;

namespace VerboseCSharpTests.TestingFramework {

    /// <summary>
    /// Sample Object, used to demonstrate using ToDisplay() with Verbose Assertion.
    /// </summary>
    public class SomeObjectWithToDisplay {

        public int SomeInt { get; set; }

        public string SomeString { get; set; }

        public string ToDisplay(){
            return "SomeInt:"+SomeInt+"\n"+
                   "SomeString:"+SomeString+"\n";
        }

        public static SomeObjectWithToDisplay BuildOne(){
            return new SomeObjectWithToDisplay(){ SomeInt=4, SomeString="hi" };
        }

        public void DoubleIt(){
            SomeInt = SomeInt * 2;
            SomeString = SomeString + SomeString;
        }

    }
}
