# Verbose
Tools to support Verbose Assertion in C-Sharp.


## What is Verbose Assertion ?

Verbose Assertion is a technique which provides a huge speedup in test construction.

The key is to represent all the fields of a class as a single string.  This string can 
be dropped into a single assertion which checks ALL fields in the object. When properly 
supported, Verbose Assertion will let you rapidly buid Assertion Coverage.


## What is Assertion Coverage ?

Assertion Coverage is the missing metric, the thing which **actually** guarantees that your 
code is correct.  

Most managers are focused on Code Coverage (CC).  This metric is easy to measure so is often used 
as a proxy for assertion coverage.  But as all coders know, code coverage 
just says if a line was invoked, not if the line was correct.  It is easy to have fundamentally 
broken code with 100% CC.

Assertion Coverage (AC) is the part of your test that checks to see if variables were changed 
correctly.  This includes asserting that most of your variables did NOT change.  This type 
of testing is difficult to measure.  I don't know of any tools that actually evaluate AC.

If you are trying to achieve high Assertion Coverage (AC), then consider the benefits of the 
Functional Programming (FP) paradigm.  Part of the power of FP is that it restricts what 
can be changed by a single method.  This reduces the space you need to verify for AC.


## How does the Verbose toolkit help me?

In order to perform verbose assertion, you need three things:

1. The ability to represent an object as a string ( JSON and YAML are both great for this )

1. The ability to copy+paste formatted strings into an assertion method

1. Reporting on string differences which a human can understand and use.


The first requirement can be fulfilled with JSON or YAML tools.  You can also construct 
your own 'ToDisplay()' methods to customize the representation.  These methods can also 
be recursed for full representation, but beware of circular references.

The second requirement is more difficult.  There are currently no Visual Studio tools which 
allow for copy+paste of formated strings into quotes.  INSTEAD the MoreAssert.StringsAreEqual() 
method will dump a completely formatted version of the 'actual' value to the console. This 
'dump' is formatted with quotes, line breaks and string joins.  You can copy and 
paste this object into the 'expect' part of your assertion.

THe third requirement is addressed by the MoreAsserts.StringsAreEqual() method.  When the 
strings differ, it will tell you exactly where they differ, and show you a section from both 
the expected and the actual values.


## What Next?

JSON and YAML have great string comparison tools that produce the kind of reports 
needed for Verbose Assertion.  I would like to write JSON and YAML specific 
versions of this utility to take advantage of that functionality.

What I want to Add ?

1. String difference reporting tells you about multiple differences in a single report.

1. JSON and YAML specific versions of this utility reuse the existing reporting tools.

1. Create another 'SmartPaster' style option which will paste multiline strings without going to 'literal mode'.

1. Build evaulators for C# code, to investigate the variable space underlying AC.


## What kind of pasting am I talking about?

You have a string which contains line breaks:  "Hi There\n\rGood to see you.";

When you paste it into an assertion, I would like to see the following:

    MoreAsserts.StringsAreEqual( "Hi There\n\r"+
                                 "Good to see you.", result );


This is much easier for a human to read.  And before you argue against that, I have been 
doing the same thing in Java for 25 years.  Visual Studio is behind the curve here.
