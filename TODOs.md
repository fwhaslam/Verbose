# Tasks
============

Looks like VisualStudio 2022 has improved paste into quotes.
  Investigate, and add new settings for this option.

add some kind of 'settings' so that:
* 'linefeeds' can be handled consistently.
* can dump 'raw literals' instead of formatted strings
* can configure indentations for the 'Copy' string.

Add PathsAreEqual() to StringAsserts ( which ignores forward vs backslash )

add vertical ruler to guide code size ( need to find settings.json )
    turns out this is a visualcode thing, not a visualstudio thing.

add message version of StringsAreEqual, more of a 'comment' element to identify what was being compared.

add message version of all asserts eg.  SomeAssert( msg, expect, actual )

EndsWith/StartsWith to show copyable string similar to StringsAreEqual
  Show a number of lines that match the line count of 'check' value.


# Objectives
============

Rebuild Java version of this project.

Assertions must have 'message' variation.

Complete Documentation with code examples.

Start on measure assertion coverage:
* tooling to review C# methods to determine the data space that a method can access.
* function level access ( values passed in and returned )
* class level access ( values passed in, returned, and exist in class )
* system level access ( values passed in, returing, in-class, and all statically accessible values )

Document standard test organization: 
    preparation, mocking, expectations, invocation, 
    result, assertion, cleanup, order, naming, access-levels
Compare to AAA ( Arrange, Act, Assert )
