// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using System.Collections;
using System.Collections.Generic;

using VerboseCSharp.Asserts;
using VerboseCSharp.Utility;

namespace VerboseCSharpTests.Asserts {

	[TestClass]
	public class VerboseAsserts_NewBugsTest {

		[TestMethod]
		public void TacticalDungeon_YamlTools_Bug_minimal() {

			// the triple slash is reduced to a double slash in IssueToDisplay()
			string source = "StrField: (\"he\\\"llo\",False)";
			string[] actual = source.Split('\n');

			// invocation
			var result = LineDiff.IssueToDisplay( null, null, actual );

			// assertions = remains 'triple' slash when displayed
			//System.Console.WriteLine("RESULT=[[[\n"+result+"\n]]]");

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
			var result = LineDiff.IssueToDisplay( null, null, actual );

			// assertions = remains 'triple' slash when displayed
//System.Console.WriteLine("RESULT=[[[\n"+result+"\n]]]");
			AreEqual( "[[\"CharField: ('x')\\n\"+\n"+
				"\t\t\"StrField: (\\\"he\\\\\\\"llo\\\",False)\\n\"+\n"+
				"\t\t\"NumField: (123,10.5)\\n\"+\n"+
				"\t\t\"\"]]\n", result );
		}

	}
}
