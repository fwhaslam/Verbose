// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

namespace VerboseCSharp.Asserts {

	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Linq;

	using static VerboseCSharp.Utility.VerboseSupport;
	using static VerboseCSharp.Utility.VerboseTools;

	/// <summary>
	/// String and collection oriented assertions.  
	/// Provides common string and collection relations as assertions.
	/// </summary>
	public class GenericCollectionAsserts {

		//=====================
		// generic collections
		//=====================

		public static void IsEmpty<T>( ICollection<T> actual ) {
			if (actual!=null && actual.Count>0 ) {
				VerboseFail("Collection is not empty");
			}
		}

		public static void IsNotEmpty<T>( ICollection<T> actual ) {
			if (actual==null) VerboseFail("Collection is null");
			if (actual.Count==0) VerboseFail("Collection is empty");
		}

		// generic collections single value
		//=========================
		
		public static void IsFirst<T>( T expect, ICollection<T> actual ) {
			//if (expect==null)) Fail("Cannot expect null for First.");
			if (actual==null || actual.Count==0) VerboseFail("Collection is empty, no first element.");
			IEnumerator<T> loop = actual.GetEnumerator();
			loop.MoveNext();	// shift to first
			var check = loop.Current;
			if ( !IsNullEquals( expect, check ) )  {
				VerboseFail("First element of collection is not a match.");
			}
		}

		public static void IsLast<T>( T expect, ICollection<T> actual ) {
			//if (expect==null)) Fail("Cannot expect null for Last.");
			if (actual==null || actual.Count==0) VerboseFail("Collection is empty, no last element.");
			IEnumerator<T> loop = actual.GetEnumerator();
			T check = default(T);
			while (loop.MoveNext()) {	// shift to last
				check = loop.Current;
			}
			if ( !IsNullEquals(expect,check) )  {
				VerboseFail("Last element of collection is not a match.");
			}
		}
		
		public static void Contains<T>( T expect, ICollection<T> actual ) {
			//if (expect==null)) Fail("Cannot expect null for Contains.");
			if (actual==null || actual.Count==0) VerboseFail("Collection is empty, no elements.");
			IEnumerator<T> loop = actual.GetEnumerator();
			while ( loop.MoveNext() ) {
				if ( expect.Equals( loop.Current ) ) return;		// found a match
			}
			VerboseFail("Collection does not contain element.");
		}

		public static void NotContains<T>( T expect, ICollection<T> actual ) {
			//if (expect==null)) Fail("Cannot expect null for NotContains.");
			if (actual==null || actual.Count==0) VerboseFail("Collection is empty, no elements.");
			IEnumerator loop = actual.GetEnumerator();
			while ( loop.MoveNext() ) {
				if ( expect.Equals( loop.Current ) ) VerboseFail("Collection contains element.");
			}
		}

		// generic collections multi value collection
		//===================================
		
		public static void StartsWith<T>( ICollection<T> expect, ICollection<T> actual ) {

			if ( expect==null || expect.Count==0 ) VerboseFail("Cannot expect with null or empty collection.");
			if ( actual==null || actual.Count==0 ) VerboseFail("Collection is empty, no elements.");
			if ( expect.Count > actual.Count ) VerboseFail("Expected collection is longer than actual collection.");

			var loopA = actual.GetEnumerator();
			var loopE = expect.GetEnumerator();
			var index = 0;
			while ( loopE.MoveNext() ) {
				loopA.MoveNext();
				if ( ! loopA.Current.Equals( loopE.Current ) ) VerboseFail("Elements stop matching at ["+index+"] position.");
				index++;
			}
		}

		public static void EndsWith<T>( ICollection<T> expect, ICollection<T> actual ) {

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
				if ( ! loopA.Current.Equals( loopE.Current ) ) {
					VerboseFail("Elements stop matching at ["+index+"] position in actual.");
				}
				index++;
			}
		}
		
		public static void Contains<T>( ICollection<T> expect, ICollection<T> actual ) {
//Console.Out.WriteLine("START");
			if ( expect==null || expect.Count==0 ) VerboseFail("Cannot expect with null or empty collection.");
			if ( actual==null || actual.Count==0 ) VerboseFail("Collection is empty, no elements.");

			int elimit = expect.Count;
			int alimit = actual.Count;
			if ( elimit > alimit ) VerboseFail("Expected collection is longer than actual collection.");

			var elist = new List<T>(expect);
			var alist = new List<T>(actual);

			int aIx=0,eIx=0,startA=0;
			while ( eIx<elimit && aIx<alimit ) {
//Console.Out.WriteLine("A["+aIx+"]="+alist[aIx]+" E["+eIx+"]="+elist[eIx]+"   eq="+ (elist[eIx]==alist[aIx]) );
				if ( ! elist[eIx++].Equals( alist[aIx++] ) ) {
					startA++;
					eIx = 0;
				}
			}

			// failed to find pattern
			if (eIx<elimit) {
				VerboseFail("Actual did not contain expected.");
			}
		}

		public static void NotContains<T>( ICollection<T> expect, ICollection<T> actual ) {
//Console.Out.WriteLine("START");
			if ( expect==null || expect.Count==0 ) VerboseFail("Cannot expect with null or empty collection.");
			if ( actual==null || actual.Count==0 ) VerboseFail("Collection is empty, no elements.");

			int elimit = expect.Count;
			int alimit = actual.Count;
			if ( elimit > alimit ) VerboseFail("Expected collection is longer than actual collection.");

			var elist = new List<T>(expect);
			var alist = new List<T>(actual);

			int aIx=0,eIx=0,startA=0;
			while ( eIx<elimit && aIx<alimit ) {
//Console.Out.WriteLine("A[" + aIx + "]=" + alist[aIx] + " E[" + eIx + "]=" + elist[eIx] + "   eq=" + (elist[eIx] == alist[aIx]));
				if ( ! elist[eIx++].Equals( alist[aIx++] ) ) {
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

		public static void StartsWith<T>( ICollection<T> actual, params T[] expect ) {
			List<T> elist = new List<T>(expect);
			StartsWith( elist, actual );
		}

		public static void EndsWith<T>( ICollection<T> actual, params T[] expect ) {
			List<T> elist = new List<T>(expect);
			EndsWith( elist, actual );
		}

		public static void Contains<T>( ICollection<T> actual, params T[] expect ) {
			List<T> elist = new List<T>(expect);
			Contains( elist, actual );
		}

		public static void NotContains<T>( ICollection<T> actual, params T[] expect ) {
			List<T> elist = new List<T>(expect);
			NotContains( elist, actual );
		}

	}

}
