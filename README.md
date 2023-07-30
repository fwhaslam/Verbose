# Verbose
Tools to support Verbose Assertion in C-Sharp.

1. [What is Verbose Assertion ?](#what-is-verbose-assertion-)
1. [What is Assertion Coverage ?](#what-is-assertion-coverage-)
1. [How does this toolkit help with Assertions ?](#how-does-this-toolkit-help-with-assertions-)
1. [Let's Try it Out](#lets-try-it-out)
1. [Bonus!](#bonus)
1. [What Next?](#what-next)


## What is Verbose Assertion ?

Verbose Assertion is a technique which provides a huge speedup in test construction.

The key is to represent all the fields of a class as a single string.  This string can 
be copy+pasted into a single assertion which then verifies ALL fields in the object. 
When properly supported, Verbose Assertion will let you rapidly build Assertion Coverage.


## What is Assertion Coverage ?

Assertion Coverage is the missing metric, the thing which **actually** guarantees that your 
code is correct.  

Most managers are focused on Code Coverage (CC).  This metric is easy to measure, so it is 
often used as a proxy for assertion coverage.  But as all coders know, code coverage just 
says that a line was touched, not that the line was correct.  It is easy to have fundamentally 
broken code with 100% CC.

Assertion Coverage (AC) is the part of your test that checks to see if data was changed 
correctly.  This includes asserting that most of your data did NOT change.  This type of 
testing is difficult to measure.  I don't know of any tools that currently evaluates AC.


## How does this toolkit help with Assertions ?

In order to perform Verbose Assertion, you need three things:

1. The ability to represent an object as a string. ( JSON and YAML are both great for this )

1. The ability to copy+paste formatted strings into test assertions.

1. Precise reports on string differences, formatted for human comprehension.


The **First** requirement can be fulfilled with JSON or YAML tools.  You could also construct 
your own 'ToDisplay()' methods to customize the representation.  This would be similar to 
a 'ToString()' method, but optimized to compactly represent the objects key values.

The **Second** requirement is more difficult.  There are currently no Visual Studio tools which 
allow for copy+paste of formatted strings into quotes.  Instead, the VerboseAsserts.StringsAreEqual() 
method will dump a completely formatted version of the 'Actual' value to the console. 

This value is formatted with quotes, tabs, line breaks and string joins.  You can copy and paste this 
object directly into the 'Expect' element of your assertion.

**Update:** as of C# version 11 raw string literals are supported.  This project does not currently 
support raw string literals.

The **Third** requirement is addressed by the VerboseAsserts.StringsAreEqual() method.  When the 
strings differ, it will throw an exception with a line difference summary, and dump a detailed 
report to the console showing exactly which lines are different and where.


## Let's Try it Out

Here is an example class built with a ToDisplay() method. [Sample](VerboseCSharpTests/TestingFramework/SomeobjectWithToDisplay.cs)

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

Create placeholder unit tests for the non-trival methods:
   
    [TestClass]
    public class SomeObjectWithToDisplayTest {

        [TestMethod]
        public void _constructor(){
            // invocation
            var results = new SomeObjectWithToDisplay();
            // assertions
            VerboseAsserts.StringsAreEqual( "", results.ToDisplay() );
        }

        [TestMethod]
        public void BuildOne_static(){
            // invocation
            var results = SomeObjectWithToDisplay.BuildOne();
            // assertions
            VerboseAsserts.StringsAreEqual( "", results.ToDisplay() );
        }
        
        [TestMethod]
        public void DoubleIt(){
            var work = SomeObjectWithToDisplay.BuildOne();
            // invocation
            work.DoubleIt();
            // assertions
            VerboseAsserts.StringsAreEqual( "", work.ToDisplay() );
        }
    }

Run the tests.  They all fail, and the Console contains strings you can copy back in.
Here is what you end up with:  [Sample](VerboseCSharpTests/TestingFramework/SomeobjectWithToDisplayTest.cs)

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

Next, lets look at how a string parser can be used.  Assume we have a YamlParser which produces 
a YAML representation of the object.  We go through the same process of creating placeholders, then 
copying in the resulting Copy string.  Here is what that looks like:  [Sample](VerboseCSharpTests/TestingFramework/SomeobjectWithToDisplayAsYamlTest.cs)

    [TestClass]
    public class SomeObjectWithToDisplayAsYamlTest {

        [TestMethod]
        public void _constructor(){
            // invocation
            var results = new SomeObjectWithToDisplay();
            // assertions
            VerboseAsserts.StringsAreEqual( 
                "SomeInt: 0\n"+
                "SomeString: \n"+
                "", YamlParser.ToYamlString(results) );
        }

        [TestMethod]
        public void BuildOne_static(){

            // invocation
            var results = SomeObjectWithToDisplay.BuildOne();

            // assertions
            VerboseAsserts.StringsAreEqual( 
                "SomeInt: 4\n"+
                "SomeString: hi\n"+
                "", YamlParser.ToYamlString(results) );
        }
        
        [TestMethod]
        public void DoubleIt(){

            var work = SomeObjectWithToDisplay.BuildOne();

            // invocation
            work.DoubleIt();

            // assertions
            VerboseAsserts.StringsAreEqual( 
                "SomeInt: 8\n"+
                "SomeString: hihi\n"+
                "", YamlParser.ToYamlString(work) );
        }
    }


## Bonus!

Consider this:  Let's say I add four more fields to SomeObjectWithToDisplay.  In the tests
I will want to assert four more values.  Normally I might add four new assertions.  But with
Verbose Assertion, it is still a SINGLE copy + paste operation using the verbose string.
The detailed report will show the four added values, which I can validate before performing 
the copy + paste operation.

Another benefit?  Adding new values to SomeObjectWithToDisplay will FORCE the Yaml tests to fail.
The ToDisplay() tests will also fail, provided ToDisplay() was updated.   This is a GOOD thing. 
Changes to code SHOULD force changes to tests.  Otherwise, what are the tests really testing?


## What Next?

What I want to Add:

1. Create another 'SmartPaster' style option which will paste multiline strings without going to 'literal mode'.

1. Build evaulators to inspect C# code, which will analyze the data space necessary for AC.
   As a first step towards meaqsuring Assertion Coverage.

1. Support for raw string literals.


## What kind of pasting would I like to create?

You have a string which contains line breaks:  "Hi There\r\nGood to see you.";

When you paste it into an assertion, I would like to see the following:

    MoreAsserts.StringsAreEqual( "Hi There\r\n"+
                                 "Good to see you.", result );

This is much easier for a human to read.  And before you argue against that, I have been 
doing the same thing in Java for 25 years.  Visual Studio is behind the curve here.
