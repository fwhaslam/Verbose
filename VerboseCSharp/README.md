# VerboseCSharp

Complete documentation can be found at:
https://github.com/fwhaslam/VerboseCSharp#readme

This package offers some common assertions for tests, 
and verbose assertions for assertion coverage.

## Common Assertions

This package contains the following common asertions:

StringAsserts:
* IsEmpty( string:actual )
* IsNotEmpty( string:actual )
* StartsWith( string:expect, string:actual )
* EndsWith( string:expect, string:actual )
* Contains( string:expect, string:actual )

CollectionAsserts
* IsEmpty( collection:actual )
* IsNotEmpty( collection:actual )
* IsFirst( object:expect, collection:actual )
* IsLast( object:expect, collection:actual )
* Contains( object:expect, collection:actual )
* NotContains( object:expect, collection:actual )
* StartsWith( collection:expect, collection:actual )
* EndsWith( collection:expect, collection:actual )
* Contains( collection:expect, collection:actual )
* NotContains( collection:expect, collection:actual )

GenericCollectionAsserts :: same as CollectionAsserts, but the objects are typed.


## Verbose Assertion

The what and why for verbose assertion are explained on the project page in github.

The how is to use this method:

    VerboseAsserts.StringsAreEqual( expect, actual );

Let's pretend we have SomeClass with three fields, and a YamlParser to produce a Yaml representation.
For our first round, we create the following placeholder test:

    [TestMethod]
    public void BuildOne_Test() {

        // invocation
        var result = SomeClass.BuildOne();

        // assertion
        StringsAreEqual( "", YamlParser.ToYamlString(result) );
    }

We run the test.  It fails and produces three things: an exception with summary information, 
a console dump with a detailed report on what is wrong, and a string that can be copied 
back into the test.  Below is the console output.

    Message: 
    Test method VerboseCSharpTests.TestingFramework.SomeObjectAsYamlTest.BuildOne_static threw exception:
    VerboseCSharp.Asserts.VerboseAssertionException: Lines Different (added=4) see report for details.
    
    Stack Trace:
    VerboseAsserts.StringsAreEqual(String expect, String actual) line 52
    SomeObjectWithToDisplayAsYamlTest.BuildOne_Test() line 29
    
    Standard Output:
    Actual Value For Copy and Paste [["SomeInt: 4\n"+
    "SomeFloat: 0.123\n"+
    "SomeString: hi\n"+
    ""]]
    
    :::: Detailed Line Difference Report ::::
    +>>: SomeInt: 4
    +>>: SomeFloat: 0.123
    +>>: SomeString: hi
    +>>:
    :::: End of Report ::::

The output starts with the summary:  "Lines Different (added=4)"
There is an 'Actual Value For Copy', which we can cut and paste back into the test.
There is a detailed report showing new lines added with "+>>" symbol.

This looks right, so we copy the 'Actual Value' back into the test for this:

    [TestMethod]
    public void BuildOne_Test() {

        // invocation
        var result = SomeClass.BuildOne();

        // assertion
        StringsAreEqual( 
            "SomeInt: 4\n"+
            "SomeFloat: 0.123\n"+
            "SomeString: hi\n"+
            "", YamlParser.ToYamlString(result) );
    }

Now the test passes.  

Any future changes may end up adding, deleting or modifying fields.  The changes 
will be explained in the report.  If the changes look good, then copy + paste the 
'Actual Value' again.  Updating is always this single operation.

Here are some things you may see in the future.  Lines removed, added, or modified.

    :::: Detailed Line Difference Report ::::
       : SomeInt: 4
    <<-: SomeFloat: 0.123
    +>>: SomeBool: false
    old: SomeString: hi
    new: SomeString: hiya
    :::: End of Report ::::
