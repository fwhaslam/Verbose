// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

namespace VerboseCSharp.Utility {

	using System;

	/// <summary>
	/// Thrown when a verbose assertion fails.
	/// Extends SystemException so that exception declarations are unnecessary.
	/// </summary>
	public class VerboseAssertionException : SystemException {

		public VerboseAssertionException( string msg ) : base(msg) {}
	}
}
