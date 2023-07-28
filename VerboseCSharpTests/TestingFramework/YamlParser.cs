// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.EventEmitters;

namespace VerboseCSharpTests.TestingFramework {

	/// <summary>
	/// see: https://stackoverflow.com/questions/58431796/change-the-scalar-style-used-for-all-multi-line-strings-when-serialising-a-dynam
	/// </summary>
	//public class MultilineScalarFlowStyleEmitter : ChainedEventEmitter {
	//	public MultilineScalarFlowStyleEmitter(IEventEmitter nextEmitter) : base(nextEmitter) { }
	//	public override void Emit(ScalarEventInfo eventInfo, IEmitter emitter) {
	//		if (typeof(string).IsAssignableFrom(eventInfo.Source.Type)) {
	//			string value = eventInfo.Source.Value as string;
	//			if (!string.IsNullOrEmpty(value)) {
	//				bool isMultiLine = value.IndexOfAny(new char[] { '\r', '\n', '\x85', '\x2028', '\x2029' }) >= 0;
	//				if (isMultiLine)
	//					eventInfo = new ScalarEventInfo(eventInfo.Source) {
	//						Style = ScalarStyle.Literal
	//					};
	//			}
	//		}
	//		nextEmitter.Emit(eventInfo, emitter);
	//	}
	//}	

	public class LongStringUseFoldedStyleEmitter : ChainedEventEmitter {

		public LongStringUseFoldedStyleEmitter(IEventEmitter nextEmitter) : base(nextEmitter) { }

		public override void Emit(ScalarEventInfo eventInfo, IEmitter emitter) {
			if (typeof(string).IsAssignableFrom(eventInfo.Source.Type)) {
				// do not override 'Literal' style
				if (eventInfo.Source.ScalarStyle!=ScalarStyle.Literal) {
					string value = eventInfo.Source.Value as string;
					if ( !string.IsNullOrEmpty(value)) {
						// some type of informative text.
						if (value.Length>=20 && value.Contains(" ")) {
							eventInfo = new ScalarEventInfo(eventInfo.Source) {
								Style = ScalarStyle.Folded
							};
						}
					}
				}
			}
			nextEmitter.Emit(eventInfo, emitter);
		}
	}

//=================================================================================================================================

	public class YamlParser {

		/// <summary>
		/// Use the same newline symbol for ALL systems.
		/// Wraparound long text at 100 chars.
        /// Indent list entries.
		/// </summary>
		internal static readonly EmitterSettings CONSISTENT_SETTINGS = 
			new EmitterSettings( 2, 100, false, 1024, false, true, "\n" );

		public static readonly ISerializer SERIALIZER = 
			Serializer.FromValueSerializer( new SerializerBuilder().BuildValueSerializer(), CONSISTENT_SETTINGS );

		static readonly IDeserializer DESERIALIZER = new Deserializer();
		
		static readonly IDeserializer DESERIALIZER_LENIENT = 
			new DeserializerBuilder().IgnoreUnmatchedProperties().Build();

//======================================================================================================================

		public static string ToYamlString( object what ) {
			return SERIALIZER.Serialize( what );
		}

		/// <summary>
		/// Default parsing.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="contents"></param>
		/// <returns></returns>
		public static T FromYamlString<T>( string contents ) {
			return DESERIALIZER.Deserialize<T>( contents );
		}

		/// <summary>
		/// Ignore unknown fields, makes loading old game saves more likely to succeed.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="contents"></param>
		/// <returns></returns>
		public static T FromYamlStringLenient<T>( string contents ) {
			return DESERIALIZER_LENIENT.Deserialize<T>( contents );
		}

	}
}
