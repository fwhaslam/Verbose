using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Verbose.Utility {

	/// <summary>
	/// Thrown when a verbose assertion fails.
	/// Extends SystemException so that exception declarations are unnecessary.
	/// </summary>
	public class VerboseAssertionException : SystemException {

		public VerboseAssertionException( string msg) : base(msg) {}
	}
}
