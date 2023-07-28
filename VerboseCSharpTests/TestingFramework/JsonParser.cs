// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections.Generic;
using System.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace VerboseCSharpTests.TestingFramework {

    public class JsonParser {
		
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
        
		internal static readonly JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings { 
			ContractResolver = new OrderedContractResolver(),
			NullValueHandling = NullValueHandling.Ignore,
			Converters = new List<JsonConverter>{ new StringEnumConverter() }
		};

//======================================================================================================================

		/// <summary>
		/// Create json/string representation of an object.
		/// </summary>
		/// <param name="what"></param>
		/// <returns></returns>
		public static string ToJsonString( object what ) {
			 return JsonConvert.SerializeObject( what ).Replace("\r","");
		}


		/// <summary>
		/// Create pretty formatted json/string representation of an object.
		/// </summary>
		/// <param name="what"></param>
		/// <returns></returns>
		public static string ToPrettyString( Object what ) {
			return JsonConvert
				// pretty indentation, alphabetical sorting
				.SerializeObject( what, Formatting.Indented, JSON_SETTINGS )
				// no line-feeds, always simple carriage returns
				.Replace("\r","");
		}
	
    }
}
