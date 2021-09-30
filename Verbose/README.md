Verbose Assertion
==================

Verbose Assertion is a technique that provides a huge speedup in test construction.

The key is to represent all the public fields of a class as a JSON object.  This result can 
then be quickly copy and pasted into a string.  The string can be used to create a single 
assertion which verifies every field in the object.  Bing bang boom!

How do you know what you should assert?  You don't.  Start with an empty string assertion.
The result of the test will display that the value looked like, and you can copy and 
paste THAT display into the expectation.  The string will be human readable, so if the 
values looks wrong you can immediately update your code to fix it.

Step One:  write assertion

    MoreAsserts.StringsAreEqual( "", myJsonResult );

Step Two:  run test, console shows

    "{\n"+
    "    "field":"value",\n"+
    "    "num":1234\n"+"
    "}"

 Step Three: copy from console into assertion

    MoreAsserts.StringsAreEqual( "{\n"+
            "    "field":"value",\n"+
            "    "num":1234\n"+"
            "}", myJsonResult );

Step Four:  nothing, you are done!
