using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp18._2
{
	public class Derived : Found
	{
		protected int debet;
		public Derived() { }
		public Derived(string name, int cred, int deb) : base(name, cred)
		{
			debet = deb;
		}
		public void DerivedMethod()
		{
			Console.WriteLine("Это метод класса Derived");
		}
		new public void Analysis()
		{
			base.Analysis();
			Console.WriteLine("Сложный анализ");
		}
		public override void VirtMethod()
		{
			Console.WriteLine("Сын: " + this.ToString());
		}
		public override string ToString()
		{
			return String.Format("поля: name = {0}, credit = {1},debet ={2}",name, credit, debet);
		}

	}
}
