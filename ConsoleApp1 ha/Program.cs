using System;
namespace Types
{
	class Class1
	{
		[STAThread]
		static void Main()
		{
            ConsoleApp1_ha.Class1.Testing tm = new ConsoleApp1_ha.Class1.Testing();
			Console.WriteLine("Лекция 3");
			Console.WriteLine("Testing.Who Test");
			tm.WhoTest();
			Console.WriteLine("\nTesting.Back Test");
			tm.BackTest();
			Console.WriteLine("\nЛекция 4");
			Console.WriteLine("Testing.OLoad Test");
			tm.OLoadTest();
			Console.WriteLine("\nTesting.ToString Test");
			tm.ToStringTest();
			//Console.WriteLine("\nTesting.FromString Test");
			//tm.FromStringTest();
		}
	}
}

