//
//	Copyright 2021 Frederick William Haslam born 1962 in the USA
//


namespace VerboseCSharp.Utility {

	using Microsoft.VisualStudio.TestTools.UnitTesting;

	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Text;
	using System.Threading.Tasks;

		using static Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

	[TestClass]
	public class ConsoleMockerTest {

		
		[TestMethod]
		public void Constructor() { 

			var writer = Console.Out;

			// invocation
			var result = new ConsoleMocker( writer );

			// assertions
			AreSame( writer, result.OutWriter);
			AreEqual( 0, result.Result.Length );
		}
		
		[TestMethod]
		public void Write_buffer() { 

			var console = new ConsoleMocker( null );

			// invocation
			console.Write( "Hello".ToCharArray(), 1, 3 );

			// assertions
			AreEqual( "ell", console.GetResult() );
		}
		
		[TestMethod]
		public void Write_string() { 

			var console = new ConsoleMocker( null );

			// invocation
			console.Write( "Hello" );

			// assertions
			AreEqual( "Hello", console.GetResult() );
		}
		
		[TestMethod]
		public void WriteLine_string() { 

			var console = new ConsoleMocker( null );

			// invocation
			console.WriteLine( "Hello" );

			// assertions
			AreEqual( "Hello\n", console.GetResult() );
		}
		
		[TestMethod]
		public void WriteLine_Object() { 

			var console = new ConsoleMocker( null );

			// invocation
			console.WriteLine( 123 );

			// assertions
			AreEqual( "123\n", console.GetResult() );
		}
		
		[TestMethod]
		public void MockConsoleOut() { 

			var startingConsole = Console.Out;

			// invocation
			var result = ConsoleMocker.MockConsoleOut();

			// assertions
			try {
				AreSame( startingConsole, result.OutWriter );

				// our writer is wrapped in a SyncWriter, so cannot directly assert
				//AreSame( result, Console.Out );

				// check that Console.Out records to our writer
				Console.Out.Write("Hello");
				AreEqual( "Hello", result.GetResult() );
			}
			// cleanup
			finally {
				result.RestoreConsoleOut();
				AreSame( startingConsole, Console.Out );
			}
		}
		
		[TestMethod]
		public void RestoreConsoleOut() { 

			var startingConsole = Console.Out;
			var console = ConsoleMocker.MockConsoleOut();

			// invocation
			console.RestoreConsoleOut();

			// assertions
			AreSame( startingConsole, Console.Out );
		}
		
		[TestMethod]
		public void GetSpecificResult() { 

			var console = new ConsoleMocker( null );
			console.WriteLine( 123 );
			var expect = "123"+Environment.NewLine;

			// invocation
			var result = console.GetSpecificResult();

			// assertions
			AreEqual( expect, result );
		}
		
		[TestMethod]
		public void GetResult() { 

			var console = new ConsoleMocker( null );
			console.WriteLine( 123 );
			var expect = "123\n";

			// invocation
			var result = console.GetResult();

			// assertions
			AreEqual( expect, result );
		}
		
	}
}
