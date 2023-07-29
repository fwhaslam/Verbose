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
		
        /// <summary>
        /// Count of operations necessary to transform one string into the other.
        /// Operations include: insertion, deletion, substitution and transposition
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static int GetDamerauLevenshteinDistance(string first, string second) {

            var bounds = new { Height = first.Length + 1, Width = second.Length + 1 };

            int[,] matrix = new int[bounds.Height, bounds.Width];

            for (int height = 0; height < bounds.Height; height++) { matrix[height, 0] = height; };
            for (int width = 0; width < bounds.Width; width++) { matrix[0, width] = width; };

            for (int height = 1; height < bounds.Height; height++) {

                for (int width = 1; width < bounds.Width; width++) {

                    int cost = (first[height - 1] == second[width - 1]) ? 0 : 1;
                    int insertion = matrix[height, width - 1] + 1;
                    int deletion = matrix[height - 1, width] + 1;
                    int substitution = matrix[height - 1, width - 1] + cost;

                    int distance = Math.Min(insertion, Math.Min(deletion, substitution));
                    if (height > 1 && width > 1 && first[height - 1] == second[width - 2] && first[height - 2] == second[width - 1]) {
                        distance = Math.Min(distance, matrix[height - 2, width - 2] + cost);
                    }

                    matrix[height, width] = distance;
                }
            }

            return matrix[bounds.Height - 1, bounds.Width - 1];
        }

        /// <summary>
        /// Returns one for identical strings, zero for no similiarty.
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static float GetSimilarityRating( string first, string second) {
        	float length = Math.Max( first.Length, second.Length );
            if (length==0) return 1f;
        	float distance = GetDamerauLevenshteinDistance( first, second );
        	return 1f - ( distance / length );
        }
	}
}
