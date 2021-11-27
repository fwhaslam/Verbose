# Tasks
============

[done] Finish GenericCollection asserts + tests

[done] renamed some assertions to be more standard ( eg.  Empty -> IsEmpty )

add vertical ruler to guide code size ( need to find settings.json )

unify with line based comparitor, may be easier to maintain and comprehend

scripts to work with developer specific properties ( local filepaths et al )


# Objectives
============

Assertions must have 'message' variation.

Complete Documentation with code examples.

create version that leverages Json

create version that leverages Yaml

create version that uses NO serialization tool

Start on measure assertion coverage:
* tooling to review C# methods to determine the variable space that a method can access.
* function level access ( values passed in and returned )
* class level access ( values passed in, returned, and exist in class )
* system level access ( values passed in, returing, in-class, and all statically accessible values )

Document standard test organization: preparation, mocking, invocation, result, assertion, order, naming, access-levels
