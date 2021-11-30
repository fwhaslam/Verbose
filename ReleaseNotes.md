* 2021/11/30 = Release 0.0.4

Changes:
Added ConsoleMocker class to mock Console.Out for test purposes.

Updated nuget script to only add timestamp for -alpha versions

Updated VerboseTools.AsPrettyString() to:
1. skip null values ( smaller output )
1. dump enums as strings ( human readable )

Switch to simpler line checking logic for StringsAreEqual() ( obsolete StringDiff class )


* 2021/11/27 = Release 0.0.3

Changes:
* Finish GenericCollection asserts + tests
* renamed some assertions to be more standard ( eg.  Empty -> IsEmpty )
* expanded on explanation of verbose assertion


2021/10/01 = Release 0.0.3-alpha

changes:
* broke assertions into more classes
* added script to publish locally to nuget repo
* added solution properties to Directory.Build.props
* completed string and non-generic collection assertions
* divided tools into internal ( support ) and external ( tools )