// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VerboseCSharp.Utility;
using System.Diagnostics;

namespace VerboseCSharpTests.Utility {

	[TestClass]
    public class AnalyzeWithDiffPlexTest {

        [TestMethod]
        public void CompareStrings() {

            var before =
                "some set of strings\r\n" +
                "something deleted\r\n" +
                "a common line\r\n" +
                "another line";

            var after =
                "some set of strings\r\n" +
                "an inserted line\r\n" +
                "a common line\r\n" +
                "another line with extra";

            // invocation
            var results = AnalyzeWithDiffPlex.CompareStrings( before, after );

            // assertions

            // summary
            AreEqual( 
                "Lines Different (added=1, removed=1, modified=1) see report for details.", 
                results.Item1 );

            // copy
            AreEqual( 
                "[[\"some set of strings\\n\"+\n"+
		        "\t\t\"an inserted line\\n\"+\n"+
		        "\t\t\"a common line\\n\"+\n"+
		        "\t\t\"another line with extra\"]]" +
                "", results.Item2 );

            // report
            AreEqual( 
                "   : some set of strings\n" +
                "<- : something deleted\n" +
                " +>: an inserted line\n" +
                "   : a common line\n" +
                "old: another line\n" +
                "new: another line with extra" +
                "", results.Item3 );
        }


        [TestMethod]
        public void CompareStrings_oneLine() {

            var before = "check";

            var after = "false check";

            // invocation
            var results = AnalyzeWithDiffPlex.CompareStrings( before, after );

            // assertions

            // summary
            AreEqual( 
                "Lines Different (modified=1) see report for details.", 
                results.Item1 );

            // copy
            AreEqual( 
                "[[\"false check\"]]" +
                "", results.Item2 );

            // report
            AreEqual( 
                "old: check\n" +
                "new: false check" +
                "", results.Item3 );
        }
    }
}
