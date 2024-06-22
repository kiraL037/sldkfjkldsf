using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp18._2
{
	public class Found
	{
		protected string name;
		protected int credit;
		public Found()
		{
		}
		public Found(string name, int sum)
		{
			this.name = name; credit = sum;
		}
		public virtual void VirtMethod()
		{
			Console.WriteLine("Отец: " + this.ToString());
		}
		public override string ToString()
		{
			return String.Format("поля: name = {0}, credit = {1}", name, credit);
		}
		public void NonVirtMethod()
		{
			Console.WriteLine("Мать: "+ this.ToString());
		}
        public void Analysis()
		{
			Console.WriteLine("Простой анализ");
		}
		public void Work()
		{
			VirtMethod();
			NonVirtMethod();
			Analysis();
		}
	}
}
