# Tasks
============

fix issue with backslashes from TacticalDungeonRealm/YamlTools

[done] switch to line checking logic ( obsolete StringDiff class )
* update to provide multiple issues, essentially one per line of difference
* try look-ahead algorithms to see if the objects become matched again.
* extract as new LineDifference class

add vertical ruler to guide code size ( need to find settings.json )

scripts to work with developer specific properties ( local filepaths et al )


# Objectives
============

Rebuild Java version of this project.

Assertions must have 'message' variation.

Complete Documentation with code examples.

Default version to remove Json / need a local pretty displayer.

create version that leverages Json
create version that leverages Yaml
create version that has NO serialization tool dependency

Start on measure assertion coverage:
* tooling to review C# methods to determine the variable space that a method can access.
* function level access ( values passed in and returned )
* class level access ( values passed in, returned, and exist in class )
* system level access ( values passed in, returing, in-class, and all statically accessible values )

Document standard test organization: 
    preparation, mocking, expectations, invocation, 
    result, assertion, cleanup, order, naming, access-levels
Compare to AAA ( Arrange, Act, Assert )
