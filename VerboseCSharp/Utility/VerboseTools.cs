// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

namespace VerboseCSharp.Utility {	

	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;

	using Newtonsoft.Json;
	using Newtonsoft.Json.Converters;
	using Newtonsoft.Json.Serialization;

	/// <summary>
	/// Utilities to create testable verbose strings.
	/// This is built over Newtonsoft.Json
	/// </summary>
	public class VerboseTools {
		
		/// <summary>
		/// Return the project directory to access test resources
		/// </summary>
		/// <returns></returns>
		static public string GetProjectDirectory() {
			string workingDir = Directory.GetCurrentDirectory();
			return Directory.GetParent(workingDir).Parent.Parent.FullName;
		}

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

		static readonly JsonSerializerSettings JSON_SETTINGS = new JsonSerializerSettings { 
			ContractResolver = new OrderedContractResolver(),
			NullValueHandling = NullValueHandling.Ignore,
			Converters = new List<JsonConverter>{ new StringEnumConverter() }
		};


		/// <summary>
		/// Wrapper for Console messaging, useful in test environments.
		/// </summary>
		/// <param name="msg"></param>
		static public void Print( string msg ) {
			Console.Out.WriteLine( msg );
		}


		/// <summary>
		/// Create json/string representation of an object.
		/// </summary>
		/// <param name="what"></param>
		/// <returns></returns>
		static public string AsString( Object what ) {
			 return JsonConvert
				.SerializeObject( what, JSON_SETTINGS )
				.Replace("\r","");
		}
		static public string ToString( Object what ) {
			return AsString( what );
		}


		/// <summary>
		/// Create pretty formatted json/string representation of an object.
		/// </summary>
		/// <param name="what"></param>
		/// <returns></returns>
		static public string AsPrettyString( Object what ) {

			return JsonConvert
				// pretty indentation, alphabetical sorting
				.SerializeObject( what, Formatting.Indented, JSON_SETTINGS )
				// no line-feeds, always simple carriage returns
				.Replace("\r","");
		}
		static public string ToPrettyString( Object what ) {
			return AsPrettyString( what );
		}
		
		/// <summary>
		/// Checks to see if generic values are equal, including the case of both being null.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="expect"></param>
		/// <param name="check"></param>
		/// <returns></returns>
		static public bool IsNullEquals<T>( T expect, T check ) {
			if (expect==null && check==null) return true;
			if (expect==null || check==null) return false;
			return expect.Equals( check );
		}

	}
}
