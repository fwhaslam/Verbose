//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//

namespace Verbose.Utility {

	using System;

	/// <summary>
	/// Thrown when a verbose assertion fails.
	/// Extends SystemException so that exception declarations are unnecessary.
	/// </summary>
	public class VerboseAssertionException : SystemException {

		public VerboseAssertionException( string msg) : base(msg) {}
	}
}
