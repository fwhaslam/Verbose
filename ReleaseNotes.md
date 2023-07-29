### 2023/07/29 = Release 1.0.0

Fixed settings for NuGet packaing.

Renamed projects as VerboseCSharp/Tests.

Rebuilt difference engine using DiffPlex.

Moved all Assert classes into package VerboseCSharp.Asserts.

VerboseAsserts.StringsAreEqual() now produces three elements:
* a summary of line differences ( added, droped, changed ) which is thrown on assertion failure.
* a copyable string in the console, which lets you copy the Actual value and paste it into your test.
* a detailed line difference report in the console, so you can see exactly what has changed.

Renamed StringAsserts.Empty() and NotEmpty() to IsEmpty() and IsNotEmpty() for consistency.

Removed the following:
* StringLinesAreEqual(), because StringsAreEqual() is sufficient.
* StringDiff.cs from utilities.
* Json and Yaml dependencies.
* VerboseDeployNugetPackage.bat = this was only deploying into local nuget repository.


### 2022/12/05 = Release 0.0.5

Fixed issue with excess slashes found in YamlTool testing

GetProjectDirectory provided as public method.


### 2021/11/30 = Release 0.0.4

Changes:
Added ConsoleMocker class to mock Console.Out for test purposes.

Updated nuget script to only add timestamp for -alpha versions

Updated VerboseTools.AsPrettyString() to:
1. skip null values ( smaller output )
1. dump enums as strings ( human readable )

Switch to simpler line checking logic for StringsAreEqual() ( obsolete StringDiff class )


### 2021/11/27 = Release 0.0.3

Changes:
* Finish GenericCollection asserts + tests
* renamed some assertions to be more standard ( eg.  Empty -> IsEmpty )
* expanded on explanation of verbose assertion


### 2021/10/01 = Release 0.0.3-alpha

changes:
* broke assertions into more classes
* added script to publish locally to nuget repo
* added solution properties to Directory.Build.props
* completed string and non-generic collection assertions
* divided tools into internal ( support ) and external ( tools )