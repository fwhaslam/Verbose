// Copyright (c) 2023 Frederick William Haslam born 1962 in the USA.
// Licensed under "The MIT License" https://opensource.org/license/mit/

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace VerboseCSharp.Utility {	

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
		/// Wrapper for Console messaging, useful in test environments.
		/// </summary>
		/// <param name="msg"></param>
		static public void Print( string msg ) {
			Console.Out.WriteLine( msg );
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
