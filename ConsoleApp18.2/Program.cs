using System;

namespace ConsoleApp18._2
{
    class Program
    {
        static void Main()
        {
			var p = new Program();
			p.TestFoundDerived();
			Console.WriteLine("\n");
			p.TestFoundDerivedReal();

		}
		public void TestFoundDerived()
		{
			Found bs = new Found("father", 777);
			Console.WriteLine("Объект bs вызывает методы базового класса");
			bs.VirtMethod();
			bs.NonVirtMethod();
			bs.Analysis();
			bs.Work();
			Derived der = new Derived();
			Console.WriteLine("Объект der вызывает методы класса родителя");
			der.VirtMethod();
			der.NonVirtMethod();
			der.Analysis();
			der.Work();
		}
		public void TestFoundDerivedReal()
		{
			Found bs = new Found("father", 777);
			Console.WriteLine("Объект bs вызывает методы класса Found");
			bs.VirtMethod();
			bs.NonVirtMethod();
			bs.Analysis();
			bs.Work();
			Derived der = new Derived("child", 888, 555);
			Console.WriteLine("Объект der вызывает методы класса Derived");
			der.DerivedMethod();
			der.VirtMethod();
			der.NonVirtMethod();
			der.Analysis();
			der.Work();
			ChildDerived chider = new ChildDerived("grandchild", 999, 444);
			Console.WriteLine("Объект chider вызывает методы ChildDerived");
			chider.VirtMethod();
			chider.NonVirtMethod();
			chider.Analysis(5);
			chider.Work();
		}
	}
}
