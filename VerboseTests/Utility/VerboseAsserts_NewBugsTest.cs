//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//

namespace VerboseTests.Utility {

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using Verbose.Utility;

	using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

	[TestClass]
	public class VerboseAsserts_NewBugsTest {

		[TestMethod]
		public void TacticalDungeon_YamlTools_Bug_minimal() {

			// the triple slash is reduced to a double slash in IssueToDisplay()
			string source = "StrField: (\"he\\\"llo\",False)";
			string[] actual = source.Split('\n');

			// invocation
			var result = VerboseAsserts.IssueToDisplay( null, null, actual );

			// assertions = remains 'triple' slash when displayed
System.Console.WriteLine("RESULT=[[[\n"+result+"\n]]]");

			AreEqual( "[[\"StrField: (\\\"he\\\\\\\"llo\\\",False)\"]]\n", result );
		}

		[TestMethod]
		public void TacticalDungeon_YamlTools_Bug() {

			// the triple slash is reduced to a double slash in IssueToDisplay()
			string source = 
				"CharField: ('x')\n"+
				"StrField: (\"he\\\"llo\",False)\n"+
				"NumField: (123,10.5)\n";
			string[] actual = source.Split('\n');

			// invocation
			var result = VerboseAsserts.IssueToDisplay( null, null, actual );

			// assertions = remains 'triple' slash when displayed
//System.Console.WriteLine("RESULT=[[[\n"+result+"\n]]]");
			AreEqual( "[[\"CharField: ('x')\\n\"+\n"+
				"\t\t\"StrField: (\\\"he\\\\\\\"llo\\\",False)\\n\"+\n"+
				"\t\t\"NumField: (123,10.5)\\n\"+\n"+
				"\t\t\"\"]]\n", result );
		}

	}
}
