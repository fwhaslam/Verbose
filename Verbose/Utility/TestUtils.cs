using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Verbose.Utility {	

	public class TestUtils {

		static readonly string NOLF_FILLER = "\\n\"+\n\t\t\t\t\"";
		static readonly string HASLF_FILLER = "\\r\\n\"+\n\t\t\t\t\"";

		/// <summary>
		/// Add alphabetical ordered to the Json serialization.
		/// </summary>
		public class OrderedContractResolver : DefaultContractResolver {
			protected override IList<JsonProperty> CreateProperties(System.Type type, MemberSerialization memberSerialization) {
				return base.CreateProperties(type, memberSerialization)
					.OrderBy(p => p.Order ?? int.MaxValue)  // Honour any explit ordering first
					.ThenBy(p => p.PropertyName)
					.ToList();
			}
		}

		public static string SerialiseAlphabeticaly(object obj) {
			return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new OrderedContractResolver() });
		}

		/// <summary>
		/// Return the project directory to access test resources
		/// </summary>
		/// <returns></returns>
		static public string GetProjectDirectory() {
			string workingDir = Directory.GetCurrentDirectory();
			return Directory.GetParent(workingDir).Parent.Parent.FullName;
		}

		/// <summary>
		/// Create json/string representation of an object.
		/// </summary>
		/// <param name="what"></param>
		/// <returns></returns>
		static public string AsString( Object what ) {
			 return JsonConvert
				.SerializeObject(what, new JsonSerializerSettings { ContractResolver = new OrderedContractResolver() })
				.Replace("\r","");
		}


		/// <summary>
		/// Create pretty formatted json/string representation of an object.
		/// </summary>
		/// <param name="what"></param>
		/// <returns></returns>
		static public string AsPrettyString( Object what ) {

			return JsonConvert
				// pretty indentation, alphabetical sorting
				.SerializeObject( what, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new OrderedContractResolver() } )
				// no line-feeds, always simple carriage returns
				.Replace("\r","");
		}
		

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

		static public T First<T>(ICollection<T> list) {
			return list.ToList().First();
		}

		static public T Last<T>(ICollection<T> list) {
			return list.ToList().Last();
		}
	}
}
