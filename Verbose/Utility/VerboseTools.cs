using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Verbose.Utility {	

	public class VerboseTools {

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

		/// <summary>
		/// Json serialize alphabetically.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		static public string SerialiseAlphabeticaly(object obj) {
			return JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings { ContractResolver = new OrderedContractResolver() });
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
		

	}
}
