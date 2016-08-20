using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSA.IO
{
	public struct ConsoleIO : IO
	{
		public void WriteLine( string arg )
		{
			Console.WriteLine( arg );
		}

		public string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}
