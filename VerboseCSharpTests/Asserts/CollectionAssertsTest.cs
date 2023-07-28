// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

using System.Collections;
using System.Collections.Generic;
using VerboseCSharp.Asserts;

namespace VerboseCSharpTests.Asserts {

    [TestClass]
    public class CollectionAssertsTest {

        List<string> MakeList(params string[] args)
        {
            return new List<string>(args);
        }

//======================================================================================================================

        [TestMethod]
        public void IsEmpty() {

            var list = new List<string>();

            CollectionAsserts.IsEmpty(list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void IsEmpty_false() {

            var list = new List<string>();
            list.Add("hi");

            CollectionAsserts.IsEmpty(list);
        }


        [TestMethod]
        public void IsNotEmpty() {

            var list = new List<string>();
            list.Add("hi");

            CollectionAsserts.IsNotEmpty(list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void IsNotEmpty_false()
        {

            var list = new List<string>();

            CollectionAsserts.IsNotEmpty(list);
        }

        [TestMethod]
        public void IsFirst()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.IsFirst("A", list);

        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void IsFirst_false_empty()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.IsFirst(null, list);

        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void IsFirst_false_outOfOrder()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.IsFirst("B", list);

        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void IsFirst_false_notAMember()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.IsFirst("D", list);

        }

        [TestMethod]
        public void IsLast()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.IsLast("C", list);

        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void IsLast_false_empty()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.IsLast(null, list);

        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void IsLast_false_outOfOrder()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.IsLast("B", list);

        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void IsLast_false_notAMember()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.IsLast("D", list);
        }

        //======================================================================================================================

        [TestMethod]
        public void StartsWith()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.StartsWith(MakeList("A"), list);
            CollectionAsserts.StartsWith(MakeList("A", "B"), list);
            CollectionAsserts.StartsWith(MakeList("A", "B", "C"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void StartsWith_false_empty()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.StartsWith(MakeList(), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void StartsWith_false_notStart()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.StartsWith(MakeList("B"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void StartsWith_false_atEnd()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.StartsWith(MakeList("C"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void StartsWith_false_notAMember()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.StartsWith(MakeList("D"), list);
        }

        //======================================================================================================================

        [TestMethod]
        public void EndsWith()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.EndsWith(MakeList("C"), list);
            CollectionAsserts.EndsWith(MakeList("B", "C"), list);
            CollectionAsserts.EndsWith(MakeList("A", "B", "C"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void EndsWith_false_empty()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.EndsWith(MakeList(), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void EndsWith_false_notEnd()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.EndsWith(MakeList("B"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void EndsWith_false_atStart()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.EndsWith(MakeList("A"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void EndsWith_false_notAMember()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.EndsWith(MakeList("D"), list);
        }

        //======================================================================================================================

        [TestMethod]
        public void Contains()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.Contains(MakeList("A"), list);
            CollectionAsserts.Contains(MakeList("B"), list);
            CollectionAsserts.Contains(MakeList("C"), list);

            CollectionAsserts.Contains(MakeList("A", "B"), list);
            CollectionAsserts.Contains(MakeList("B", "C"), list);

            CollectionAsserts.Contains(MakeList("A", "B", "C"), list);

        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void Contains_false_empty()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.Contains(MakeList(), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void Contains_false_notAMember()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.Contains(MakeList("D"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void Contains_false_outOfOrder()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.Contains(MakeList("B", "A"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void Contains_false_skippedMember()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.Contains(MakeList("A", "C"), list);
        }

        //======================================================================================================================


        [TestMethod]
        public void NotContains()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(MakeList("D"), list);
            CollectionAsserts.NotContains(MakeList("B", "A"), list);
            CollectionAsserts.NotContains(MakeList("A", "C"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_false_Empty()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(MakeList(), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_false_matchFirst()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(MakeList("A"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_false_matchSecond()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(MakeList("B"), list);
        }


        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_false_matchThird()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(MakeList("C"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotNotContains_false_matchStart()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(MakeList("A", "B"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_false_matchEnd()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(MakeList("B", "C"), list);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_false_matchAll()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(MakeList("A", "B", "C"), list);
        }

        //======================================================================================================================


        [TestMethod]
        public void StartsWith_params()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.StartsWith(list, "A");
            CollectionAsserts.StartsWith(list, "A", "B");
            CollectionAsserts.StartsWith(list, "A", "B", "C");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void StartsWith_params_false_empty()
        {

            var list = MakeList("A", "B", "C");
            object[] emptyList = { };

            CollectionAsserts.StartsWith(list, emptyList);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void StartsWith_params_false_notStart()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.StartsWith(list, "B");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void StartsWith_params_false_atEnd()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.StartsWith(list, "C");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void StartsWith_params_false_notAMember()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.StartsWith(list, "D");
        }

        //======================================================================================================================

        [TestMethod]
        public void EndsWith_params()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.EndsWith(list, "C");
            CollectionAsserts.EndsWith(list, "B", "C");
            CollectionAsserts.EndsWith(list, "A", "B", "C");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void EndsWith_params_false_empty()
        {

            var list = MakeList("A", "B", "C");
            object[] emptyList = { };

            CollectionAsserts.EndsWith(list, emptyList);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void EndsWith_params_false_notEnd()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.EndsWith(list, "B");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void EndsWith_params_false_atStart()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.EndsWith(list, "A");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void EndsWith_params_false_notAMember()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.EndsWith(list, "D");
        }

        //======================================================================================================================

        [TestMethod]
        public void Contains_params()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.Contains(list, "A");
            CollectionAsserts.Contains(list, "B");
            CollectionAsserts.Contains(list, "C");

            CollectionAsserts.Contains(list, "A", "B");
            CollectionAsserts.Contains(list, "B", "C");

            CollectionAsserts.Contains(list, "A", "B", "C");

        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void Contains_params_false_empty()
        {

            var list = MakeList("A", "B", "C");
            object[] emptyList = { };

            CollectionAsserts.Contains(list, emptyList);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void Contains_params_false_notAMember()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.Contains(list, "D");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void Contains_params_false_outOfOrder()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.Contains(list, "B", "A");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void Contains_params_false_skippedMember()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.Contains(list, "A", "C");
        }

        //======================================================================================================================


        [TestMethod]
        public void NotContains_params()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(list, "D");
            CollectionAsserts.NotContains(list, "B", "A");
            CollectionAsserts.NotContains(list, "A", "C");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_params_false_Empty()
        {

            var list = MakeList("A", "B", "C");
            object[] emptyList = { };

            CollectionAsserts.NotContains(list, emptyList);
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_params_false_matchFirst()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(list, "A");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_params_false_matchSecond()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(list, "B");
        }


        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_params_false_matchThird()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(list, "C");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotNotContains_params_false_matchStart()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(list, "A", "B");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_params_false_matchEnd()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(list, "B", "C");
        }

        [TestMethod]
        [ExpectedException(typeof(VerboseAssertionException))]
        public void NotContains_params_false_matchAll()
        {

            var list = MakeList("A", "B", "C");

            CollectionAsserts.NotContains(list, "A", "B", "C");
        }


    }
}
