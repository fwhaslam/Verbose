


namespace Verbose.Utility {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	using static Verbose.Utility.VerboseSupport;

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
				VerboseFail("Collection is not empty");
			}
		}

		static public void NotEmpty( ICollection actual ) {
			if (actual==null) VerboseFail("Collection is null");
			if (actual.Count==0) VerboseFail("Collection is empty");
		}

		// collections single value
		//=========================
		
		static public void IsFirst( object expect, ICollection actual ) {
			//if (expect==null)) Fail("Cannot expect null for First.");
			if (actual==null || actual.Count==0) VerboseFail("Collection is empty, no first element.");
			IEnumerator loop = actual.GetEnumerator();
			loop.MoveNext();	// shift to first
			if ( expect != loop.Current )  {
				VerboseFail("First element of collection is not a match.");
			}
		}

		static public void IsLast( object expect, ICollection actual ) {
			//if (expect==null)) Fail("Cannot expect null for Last.");
			if (actual==null || actual.Count==0) VerboseFail("Collection is empty, no last element.");
			IEnumerator loop = actual.GetEnumerator();
			object check = null;
			while (loop.MoveNext()) check = loop.Current;	// shift to last
			if ( expect != check )  {
				VerboseFail("Last element of collection is not a match.");
			}
		}
		
		static public void Contains( object expect, ICollection actual ) {
			//if (expect==null)) Fail("Cannot expect null for Contains.");
			if (actual==null || actual.Count==0) VerboseFail("Collection is empty, no elements.");
			IEnumerator loop = actual.GetEnumerator();
			while ( loop.MoveNext() ) {
				if (expect == loop.Current) return;		// found a match
			}
			VerboseFail("Collection does not contain element.");
		}

		static public void NotContains( object expect, ICollection actual ) {
			//if (expect==null)) Fail("Cannot expect null for NotContains.");
			if (actual==null || actual.Count==0) VerboseFail("Collection is empty, no elements.");
			IEnumerator loop = actual.GetEnumerator();
			while ( loop.MoveNext() ) {
				if (expect == loop.Current) VerboseFail("Collection contains element.");
			}
		}

		// collections multi value collection
		//===================================
		
		static public void StartsWith( ICollection expect, ICollection actual ) {

			if ( expect==null || expect.Count==0 ) VerboseFail("Cannot expect with null or empty collection.");
			if ( actual==null || actual.Count==0 ) VerboseFail("Collection is empty, no elements.");
			if ( expect.Count > actual.Count ) VerboseFail("Expected collection is longer than actual collection.");

			var loopA = actual.GetEnumerator();
			var loopE = expect.GetEnumerator();
			var index = 0;
			while ( loopE.MoveNext() ) {
				loopA.MoveNext();
				if ( loopA.Current != loopE.Current ) VerboseFail("Elements stop matching at ["+index+"] position.");
				index++;
			}
		}

		static public void EndsWith( ICollection expect, ICollection actual ) {

			if ( expect==null || expect.Count==0 ) VerboseFail("Cannot expect with null or empty collection.");
			if ( actual==null || actual.Count==0 ) VerboseFail("Collection is empty, no elements.");
			if ( expect.Count > actual.Count ) VerboseFail("Expected collection is longer than actual collection.");

			int skip = actual.Count - expect.Count;

			var loopA = actual.GetEnumerator();
			var loopE = expect.GetEnumerator();

			var index = 0;
			for (;index<skip;index++) loopA.MoveNext();

			while ( loopE.MoveNext() ) {
				loopA.MoveNext();
				if ( loopA.Current != loopE.Current ) {
					VerboseFail("Elements stop matching at ["+index+"] position in actual.");
				}
				index++;
			}
		}
		
		static public void Contains( ICollection expect, ICollection actual ) {
//Console.Out.WriteLine("START");
			if ( expect==null || expect.Count==0 ) VerboseFail("Cannot expect with null or empty collection.");
			if ( actual==null || actual.Count==0 ) VerboseFail("Collection is empty, no elements.");

			int elimit = expect.Count;
			int alimit = actual.Count;
			if ( elimit > alimit ) VerboseFail("Expected collection is longer than actual collection.");

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
				VerboseFail("Actual did not contain expected.");
			}
		}

		static public void NotContains( ICollection expect, ICollection actual ) {
//Console.Out.WriteLine("START");
			if ( expect==null || expect.Count==0 ) VerboseFail("Cannot expect with null or empty collection.");
			if ( actual==null || actual.Count==0 ) VerboseFail("Collection is empty, no elements.");

			int elimit = expect.Count;
			int alimit = actual.Count;
			if ( elimit > alimit ) VerboseFail("Expected collection is longer than actual collection.");

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
				VerboseFail("Actual does contain expected.");
			}
		}

		
		// collections multi value params :: NOTE that params are last in list, breaking the pattern
		//===================================

		static public void StartsWith( ICollection actual, params object[] expect ) {
			List<object> elist = new List<object>(expect);
			StartsWith( elist, actual );
		}

		static public void EndsWith( ICollection actual, params object[] expect ) {
			List<object> elist = new List<object>(expect);
			EndsWith( elist, actual );
		}

		static public void Contains( ICollection actual, params object[] expect ) {
			List<object> elist = new List<object>(expect);
			Contains( elist, actual );
		}

		static public void NotContains( ICollection actual, params object[] expect ) {
			List<object> elist = new List<object>(expect);
			NotContains( elist, actual );
		}

	}

}
