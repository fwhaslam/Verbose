// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace VerboseCSharp.Utility {	

	public class VerboseSupport {

		static internal void VerboseFail(string msg) {
			throw new VerboseAssertionException(msg);
		}
	
		// Linq Placeholders for net4.7.1 :: avaialble via Linq for net5.0

		static internal T First<T>(ICollection<T> list) {
			return list.ToList().First();
		}

		static internal T Last<T>(ICollection<T> list) {
			return list.ToList().Last();
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
	}
}
