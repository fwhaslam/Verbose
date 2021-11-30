# Tasks
============

[done] Added utility to mock Console.Out for test purposes.

[done] updated nuget script to only add timestamp for -alpha versions

[done] Updated AsPrettyString() to:
1. [done] skip null values ( smaller output )
1. [done] dump enums as strings ( human readable )

[done] switch to line checking logic ( obsolete StringDiff class )
* update to provide multiple issues, essentially one per line of difference
* try look-ahead algorithms to see if the objects become matched again.

add vertical ruler to guide code size ( need to find settings.json )

scripts to work with developer specific properties ( local filepaths et al )


# Objectives
============

Assertions must have 'message' variation.

Complete Documentation with code examples.

Default version to remove Json / need a local pretty displayer.

create version that leverages Json

create version that leverages Yaml

create version that uses NO serialization tool

Start on measure assertion coverage:
* tooling to review C# methods to determine the variable space that a method can access.
* function level access ( values passed in and returned )
* class level access ( values passed in, returned, and exist in class )
* system level access ( values passed in, returing, in-class, and all statically accessible values )

Document standard test organization: preparation, mocking, invocation, result, assertion, cleanup, order, naming, access-levels
