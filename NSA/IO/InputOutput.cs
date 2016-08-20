using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NSA.IO
{	
	//Interface for DI
	public interface IO
	{
		void WriteLine(string arg);
		string ReadLine();
	}
}

