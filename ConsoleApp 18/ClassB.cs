using System;

namespace ConsoleApp_18
{
	public class ClassB
	{
		public ClassB(string f1A, int f2A, string f1B, int f2B)
		{
			inner = new ClassA(f1A, f2A);
			fieldB1 = f1B; fieldB2 = f2B;
		}
		ClassA inner;
		public string fieldB1;
		public int fieldB2;
		public void MethodB1()
		{
			inner.MethodA();
			Console.WriteLine("Это класс B");
			Console.WriteLine("поле1 = {0}, поле2 = {1}",
				fieldB1, fieldB2);
		}
		public void MethodB2()
		{
			ClassA loc = new ClassA("локальный объект А", 77);
			loc.MethodA();
		}
		public void MethodB3()
		{
			ClassA.StatMethodA();
		}

	}
}