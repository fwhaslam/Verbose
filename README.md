# Verbose
Tools to support Verbose Assertion in C-Sharp.


## What is Verbose Assertion ?

Verbose Assertion is a technique which provides a huge speedup in test construction.

The key is to represent all the externally accessible fields of a class as a single string.  
This string can be used in a single assertion which checks ALL fields in the object.  
When properly supported, verbose assertion can raise assertion coverage to record highs.


## What is Assertion Coverage ?

Assertion Coverage is the missing metric, the thing which *actually* guarantees that your 
code is correct.  

Most managers are focused on Code Coverage.  This metric is easy to measure and check,
so is often used as a proxy of good test coverage.  But as all coders know, code coverage 
just says if a line was invoked, not if the line was correct.  You can have 100% coverage 
against code which is fundamentally broken.

Assertion Coverage are the parts of your test which check that variables in the system 
have been changed correctly, or NOT changed correctly.  Checking that things have NOT 
changed is critical to good assertion coverage.  This type of testing is difficult to 
measure.  There are few automation tools which even try to measure Assertion Coverage.  

Perfect assertion coverage would mean checking EVERY variable in the system after 
any method invocation.  Part of the power of Functional Programming is that it severely 
restricts which objects can be affected by some method, consequently reducing the space 
which needs to be checked for perfect Assertion Coverage.


## How does the Verbose toolkit help me?

In order to perform verbose assertion, you need three things:

1. The ability to represent an object as a string ( JSON and YAML are both great for this )

1. The ability to copy+paste formatted strings into an assertion method

1. Reporting on string differences which a human can understand and use.


The first requirement can be fulfilled with JSON and YAML tools.  You can also construct 
your own 'ToDisplay()' methods to customize the representation.  These methods can also 
be recursed for full representation, but be careful of circular references.

The second requirement is more difficult.  There are currently no Visual Studio tools which 
allow for copy+paste of formated strings into quotes.  INSTEAD the MoreAssert.StringsAreEqual() 
method will dump a completely formatted version of the 'actual' value to the console.
This 'dump' is formatted with quotes, line breaks and string joins.  You can copy and 
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


## What kind of pasting am I talking about?

You have a string which contains line breaks:  "Hi There\n\rGood to see you.";

When you paste it into an assertion, I would like to see the following:

    MoreAsserts.StringsAreEqual( "Hi There\n\r"+
                                 "Good to see you.", result );


This is much easier for a human to read.  And before you argue against that, I have been 
doing the same thing in Java for 25 years.  Visual Studio is behind the curve here.
