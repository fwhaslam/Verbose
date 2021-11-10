using Microsoft.VisualStudio.TestTools.UnitTesting;

using System;
using System.Collections;
using System.Collections.Generic;

using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;


namespace Verbose.Utility {

	using System.Linq;

	/// <summary>
	/// String and collection oriented assertions.  
	/// Provides common string and collection relations as assertions.
	/// </summary>
	public class CollectionAsserts {

		//=====================
		// collections
		//=====================

		static public void Empty( ICollection actual ) {
			if (actual!=null && actual.Count>0 ) {
				Fail("Collection is not empty");
			}
		}

		static public void NotEmpty( ICollection actual ) {
			if (actual==null) Fail("Collection is null");
			if (actual.Count==0) Fail("Collection is empty");
		}

		// collections single value
		//=========================
		
		static public void First( object expect, ICollection actual ) {
			//if (expect==null)) Fail("Cannot expect null for First.");
			if (actual==null || actual.Count==0) Fail("Collection is empty, no first element.");
			IEnumerator loop = actual.GetEnumerator();
			loop.MoveNext();	// shift to first
			if ( expect != loop.Current )  {
				Fail("First element of collection is not a match.");
			}
		}

		static public void Last( object expect, ICollection actual ) {
			//if (expect==null)) Fail("Cannot expect null for Last.");
			if (actual==null || actual.Count==0) Fail("Collection is empty, no last element.");
			IEnumerator loop = actual.GetEnumerator();
			object check = null;
			while (loop.MoveNext()) check = loop.Current;	// shift to last
			if ( expect != check )  {
				Fail("Last element of collection is not a match.");
			}
		}
		
		static public void Contains( object expect, ICollection actual ) {
			//if (expect==null)) Fail("Cannot expect null for Contains.");
			if (actual==null || actual.Count==0) Fail("Collection is empty, no elements.");
			IEnumerator loop = actual.GetEnumerator();
			while ( loop.MoveNext() ) {
				if (expect == loop.Current) return;		// found a match
			}
			Fail("Collection does not contain element.");
		}

		static public void NotContains( object expect, ICollection actual ) {
			//if (expect==null)) Fail("Cannot expect null for NotContains.");
			if (actual==null || actual.Count==0) Fail("Collection is empty, no elements.");
			IEnumerator loop = actual.GetEnumerator();
			while ( loop.MoveNext() ) {
				if (expect == loop.Current) Fail("Collection contains element.");
			}
		}

		// collections multi value collection
		//===================================
		
		static public void StartsWith( ICollection expect, ICollection actual ) {

			if ( expect==null || expect.Count==0 ) Fail("Cannot expect with null or empty collection.");
			if ( actual==null || actual.Count==0 ) Fail("Collection is empty, no elements.");
			if ( expect.Count > actual.Count ) Fail("Expected collection is longer than actual collection.");

			var loopA = actual.GetEnumerator();
			var loopE = expect.GetEnumerator();
			var index = 0;
			while ( loopE.MoveNext() ) {
				loopA.MoveNext();
				if ( loopA.Current != loopE.Current ) Fail("Elements stop matching at ["+index+"] position.");
				index++;
			}
		}

		static public void EndsWith( ICollection expect, ICollection actual ) {

			if ( expect==null || expect.Count==0 ) Fail("Cannot expect with null or empty collection.");
			if ( actual==null || actual.Count==0 ) Fail("Collection is empty, no elements.");
			if ( expect.Count > actual.Count ) Fail("Expected collection is longer than actual collection.");

			int skip = actual.Count - expect.Count;

			var loopA = actual.GetEnumerator();
			var loopE = expect.GetEnumerator();

			var index = 0;
			for (;index<skip;index++) loopA.MoveNext();

			while ( loopE.MoveNext() ) {
				loopA.MoveNext();
				if ( loopA.Current != loopE.Current ) {
					Fail("Elements stop matching at ["+index+"] position in actual.");
				}
				index++;
			}
		}
		
		[TestMethod]
		static public void Contains( ICollection expect, ICollection actual ) {
//Console.Out.WriteLine("START");
			if ( expect==null || expect.Count==0 ) Fail("Cannot expect with null or empty collection.");
			if ( actual==null || actual.Count==0 ) Fail("Collection is empty, no elements.");

			int elimit = expect.Count;
			int alimit = actual.Count;
			if ( elimit > alimit ) Fail("Expected collection is longer than actual collection.");

			var elist = new ArrayList(expect);
			var alist = new ArrayList(actual);

			int aIx=0,eIx=0,startA=0;
			while ( eIx<elimit && aIx<alimit ) {
//Console.Out.WriteLine("A["+aIx+"]="+alist[aIx]+" E["+eIx+"]="+elist[eIx]+"   eq="+ (elist[eIx]==alist[aIx]) );
				if (elist[eIx++]!=alist[aIx++]) {
					startA++;
					eIx = 0;
				}
			}

			// failed to find pattern
			if (eIx<elimit) {
				Fail("Actual did not contain expected.");
			}
		}

		static public void NotContains( ICollection expect, ICollection actual ) {
//Console.Out.WriteLine("START");
			if ( expect==null || expect.Count==0 ) Fail("Cannot expect with null or empty collection.");
			if ( actual==null || actual.Count==0 ) Fail("Collection is empty, no elements.");

			int elimit = expect.Count;
			int alimit = actual.Count;
			if ( elimit > alimit ) Fail("Expected collection is longer than actual collection.");

			var elist = new ArrayList(expect);
			var alist = new ArrayList(actual);

			int aIx=0,eIx=0,startA=0;
			while ( eIx<elimit && aIx<alimit ) {
//Console.Out.WriteLine("A[" + aIx + "]=" + alist[aIx] + " E[" + eIx + "]=" + elist[eIx] + "   eq=" + (elist[eIx] == alist[aIx]));
				if (elist[eIx++]!=alist[aIx++]) {
					startA++;
					eIx = 0;
				}
			}

			// found the pattern
			if (eIx>=elimit) {
				Fail("Actual does contain expected.");
			}
		}

		
		// collections multi value params
		//===================================

		static public void StartsWith( ICollection actual, params object[] expect ) {

			Assert.Fail("write me");
		}

		static public void EndsWith( ICollection actual, params object[] expect ) {
			Assert.Fail("write me");
		}

		[TestMethod]
		static public void Contains( ICollection actual, params object[] expect ) {
			Assert.Fail("write me");
		}

		static public void NotContains( ICollection actual, params object[] expect ) {
			Assert.Fail("write me");
		}

	}

}
