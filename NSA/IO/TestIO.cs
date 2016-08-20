using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace NSA.IO
{
	public sealed class TestIO : IO
	{
		public void WriteLine( string arg )
		{
			Debug.WriteLine( arg );
		}

		public string ReadLine()
		{
			return string.Empty;
		}
	}
}
