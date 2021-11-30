//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//

namespace Verbose.Utility {

	using System;
	using System.Globalization;
	using System.IO;
	using System.Text;

	/// <summary>
	/// TextWriter that can be used to replace Console.Out for test purposes.
	/// </summary>
	public class ConsoleMocker : TextWriter {

		// Record all writes to TextWriter
		internal StringBuilder Result = new StringBuilder();
		internal TextWriter OutWriter;

		public override Encoding Encoding => Encoding.Default;

		internal ConsoleMocker( TextWriter outWriter) : base(CultureInfo.InvariantCulture) { 
			this.OutWriter = outWriter;
		}

//======================================================================================================================
//		TextWriter methods

		public override void Write(char[] buffer, int index, int count) {
			for (int i = 0; i < count; i++) {
				Result.Append( buffer[index + i] );
			}
		}

		public override void Write(string value) {
			Result.Append( value );
		}

		public override void WriteLine() {
			Result.Append( Environment.NewLine );
		}

		public override void WriteLine(string value) {
			Result.Append( value ).Append( Environment.NewLine);
		}

		public override void WriteLine(object value) {
			Result.Append( value ).Append( Environment.NewLine);
		}

//======================================================================================================================
//		Testing methods

		/// <summary>
		/// Replaces the Console.Out, and stores it for later restoration.
		/// </summary>
		/// <returns></returns>
		static public ConsoleMocker MockConsoleOut() {
			var writer = new ConsoleMocker( Console.Out );
			Console.SetOut( writer );
			return writer;
		}

		/// <summary>
		/// This should be called in a 'finally' block after a try block which mocks the console.
		/// </summary>
		public void RestoreConsoleOut() {
			Console.SetOut( OutWriter );
		}

		/// <summary>
		/// System specific result, includes carriage returns (\r) for windows.
		/// </summary>
		/// <returns></returns>
		public string GetSpecificResult() {
			return Result.ToString();
		}

		/// <summary>
		/// System agnostic result, remove all carriage returns (\r).  EndOfLine is now simply line feed (\n).
		/// </summary>
		/// <returns></returns>
		public string GetResult() {
			return Result.Replace("\r","").ToString();
		}
	}
}
