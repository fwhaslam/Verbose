# Tasks
============

(?) publish to nuget: https://www.nuget.org/
figure out a better way to export/import the DLL
see: VerboseDeployNugetPackage.bat

Update to build for .net #8 as well as .net 4.7.1

add some kind of 'settings' so things like 'linefeeds' can be handle consistently.

Remove Yaml/Json dependency.

Update Verbose utilities:
* stringsAreEqual should have one line say 'expect' and next line say 'actual'
Verbose - add comments to StringDisplay with line numbers :: // line 70 ...
Verbose update yaml to disable aliases (DisableAliases())
Migrate FlakyAnnotation to VerboseCSharp().
Add PathsAreEqual() to StringAsserts ( which ignores forward vs backslash )

split packages:
/Asserts
/Support


fix issue with backslashes from TacticalDungeonRealm/YamlTools [done]


[done] switch to line checking logic ( obsolete StringDiff class )
* update to provide multiple issues, essentially one per line of difference
* try look-ahead algorithms to see if the objects become matched again.
* extract as new LineDifference class

add vertical ruler to guide code size ( need to find settings.json )

scripts to work with developer specific properties ( local filepaths et al )

EndsWith/StartsWith to show copyable string similar to StringsAreEqual
  Show a number of lines that match the line count of 'check' value.


# Objectives
============

Rebuild Java version of this project.

Assertions must have 'message' variation.

Complete Documentation with code examples.

Default version to remove Json dependency / need a local pretty displayer.

create version that leverages Json
create version that leverages Yaml
create version that has NO serialization tool dependency
  maybe simple implementations of json + yaml to avoid library dependency

Start on measure assertion coverage:
* tooling to review C# methods to determine the variable space that a method can access.
* function level access ( values passed in and returned )
* class level access ( values passed in, returned, and exist in class )
* system level access ( values passed in, returing, in-class, and all statically accessible values )

Document standard test organization: 
    preparation, mocking, expectations, invocation, 
    result, assertion, cleanup, order, naming, access-levels
Compare to AAA ( Arrange, Act, Assert )
