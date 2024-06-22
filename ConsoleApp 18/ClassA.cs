using System;

namespace ConsoleApp_18
{
	public class ClassA
	{
		public ClassA(string f1, int f2)
		{
			fieldA1 = f1; fieldA2 = f2;
		}
		public string fieldA1;
		public int fieldA2;
		public void MethodA()
		{
			Console.WriteLine("Это класс A");
			Console.WriteLine("поле1 = {0}, поле2 = {1}",
				fieldA1, fieldA2);
		}
		public static void StatMethodA()
		{
			string s1 = "Статический метод класса А";
			string s2 = "Помните: 2*2 = 4";
			Console.WriteLine(s1 + " ***** " + s2);
		}
	}
}