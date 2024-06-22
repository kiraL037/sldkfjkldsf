using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1_ha
{
	class Class1
	{
		public class Testing
		{
			byte b = 255;
			int x = 11;
			uint ux = 1111;
			float y = 5.5f;
			double dy = 5.55;
			string s = "Hello!";
			string s1 = "25";
			object obj = new Object();
			void WhoIsWho(string name, object any)
			{
				Console.WriteLine("type {0} is {1} , value is {2}",
					name, any.GetType(), any.ToString());
			}
			public void WhoTest()
			{
				WhoIsWho("x", x);
				WhoIsWho("ux", ux);
				WhoIsWho("y", y);
				WhoIsWho("dy", dy);
				WhoIsWho("s", s);
				WhoIsWho("11 + 5.55 + 5.5f", 11 + 5.55 + 5.5f);
				obj = 11 + 5.55 + 5.5f;
				WhoIsWho("obj", obj);
			}
			object Back(object any)
			{
				return (any);
			}
			public void BackTest()
			{
				ux = (uint)Back(ux);
				WhoIsWho("ux", ux);
				s1 = (string)Back(s);
				WhoIsWho("s1", s1);
				x = (int)(uint)Back(ux);
				WhoIsWho("x", x);
				y = (float)(double)Back(11 + 5.55 + 5.5f);
				WhoIsWho("y", y);
			}
			void OLoad(float par)
			{
				Console.WriteLine("float value {0}", par);
			}
			void OLoad(long par)
			{
				Console.WriteLine("long value {0}", par);
			}
			void OLoad(ulong par)
			{
				Console.WriteLine("ulong value {0}", par);
			}
			void OLoad(double par)
			{
				Console.WriteLine("double value {0}", par);
			}
			void OLoad(long par1, long par2)
			{
				Console.WriteLine("long par1 {0}, long par2 {1}", par1, par2);
			}
			void OLoad(double par1, double par2)
			{
				Console.WriteLine("double par1 {0}, double par2 {1}", par1, par2);
			}
			void OLoad(int par1, float par2)
			{
				Console.WriteLine("int par1 {0}, float par2 {1}", par1, par2);
			}
			public void OLoadTest()
			{
				OLoad(x); OLoad(ux);
				OLoad(y); OLoad(dy);
				OLoad(x, (float)ux);
				OLoad(y, dy); OLoad(x, dy);
			}
			public void ToStringTest()
			{
				s = "Владимир Петров ";
				s1 = " Возраст: "; ux = 27;
				s = s + s1 + ux.ToString();
				s1 = " Зарплата: "; dy = 2700.50;
				s = s + s1 + dy;
				WhoIsWho("s", s);
			}
			public void FromStringTest()
			{
				s = "Введите возраст ";
				Console.WriteLine(s);
				s1 = Console.ReadLine();
				ux = Convert.ToUInt32(s1);
				WhoIsWho("Возраст: ", ux);
				s = "Введите зарплату ";
				Console.WriteLine(s);
				s1 = Console.ReadLine();
				dy = Convert.ToDouble(s1);
				WhoIsWho("Зарплата: ", dy);
			}
		}
	}
}
