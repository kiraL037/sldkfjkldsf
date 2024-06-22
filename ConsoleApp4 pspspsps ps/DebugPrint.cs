using System;
using System.Diagnostics;

namespace ConsoleApp4_pspspsps_ps
{
    public class DebugPrint
	{
		[Conditional("DEBUG")] static public void PrintEntry(string name)
		{
			Console.WriteLine("Начал работать метод " + name);
		}
		[Conditional("DEBUG")] static public void PrintExit(string name)
		{
			Console.WriteLine("Закончил работать метод " + name);
		}
		[Conditional("DEBUG")] static public void PrintObject(object obj, string name)
		{ 
			Console.WriteLine("Объект {0}: {1}", name,
				obj.ToString());
		}
	}

}
