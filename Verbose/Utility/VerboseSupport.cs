using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Verbose.Utility {	

	public class VerboseSupport {

		static internal void VerboseFail(string msg) {
			throw new VerboseAssertionException(msg);
		}

		/// <summary>
		/// Return the project directory to access test resources
		/// </summary>
		/// <returns></returns>
		static internal string GetProjectDirectory() {
			string workingDir = Directory.GetCurrentDirectory();
			return Directory.GetParent(workingDir).Parent.Parent.FullName;
		}
	
//======================================================================================================================
	
		static readonly internal string NOLF_FILLER = "\\n\"+\n\t\t\t\t\"";
		static readonly internal string HASLF_FILLER = "\\r\\n\"+\n\t\t\t\t\"";

		/// <summary>
		/// Create a 'code' visualization of a string representation.
		/// This will be printed in MoreAsserts.StringsAreEqual 
		/// which permits for a quick copy+paste to update test assertions.
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		static internal string ToCodeString( string value ) {

			bool hasLinefeed = value.Contains("\r");
			string split = ( hasLinefeed ? "\r\n" : "\n" );
			string join = ( hasLinefeed ? HASLF_FILLER : NOLF_FILLER );

			string work = value.
				// unicode made explicit
				Replace("\\u","\\\\u").
				// implicit backslashes become explicit backslashes
				Replace("\"", "\\\"");
			string joined = work.Replace( split, join );
			return "\"" + joined + "\"";

		}

		// Linq Placeholders for net4.7.1

		static internal T First<T>(ICollection<T> list) {
			return list.ToList().First();
		}

		static internal T Last<T>(ICollection<T> list) {
			return list.ToList().Last();
		}
	}
}
