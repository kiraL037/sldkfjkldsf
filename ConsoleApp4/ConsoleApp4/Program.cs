using System;
using System.Drawing;

namespace ConsoleApp4
{
    internal class Program
    {
        static void Main(string[] args)
        {
			TestPointAndSize();
            Console.WriteLine("\n");
			TestTwoSemantics();
            Console.WriteLine("\n");
			TestEnum();
			TestProfession();
            Console.WriteLine("\n");
        }
		public static void TestPointAndSize()
		{
			Point pt1 = new Point(3, 5), pt2 = new Point(7, 10), pt3;
			PointF pt4 = new PointF(4.55f, 6.75f);
			Size sz1 = new Size(10, 20), sz2;
			SizeF sz3 = new SizeF(10.3f, 20.7f);
			pt3 = Point.Round(pt4);
			sz2 = new Size(pt1);
			Console.WriteLine("pt1: " + pt1);
			Console.WriteLine("sz2 =new Size(pt1): " + sz2);
			Console.WriteLine("pt4: " + pt4);
			Console.WriteLine("pt3 =Point.Round(pt4): " + pt3);
			pt1.Offset(5, 7);
			Console.WriteLine("pt1.Offset(5,7): " + pt1);
			Console.WriteLine("pt2: " + pt2);
			pt2 = pt2 + sz2;
			Console.WriteLine("pt2= pt2+ sz2: " + pt2);
		}
		public static void TestTwoSemantics()
		{
			Console.WriteLine("Структуры: присваивание развернутого типа!");
		
			Point pt1 = new Point(3, 5), pt2;
			pt2 = pt1;
			Console.WriteLine("pt1: " + pt1);
			Console.WriteLine("pt2=pt1: " + pt2);
			pt1.X += 10;
			Console.WriteLine("pt1.X =pt1.X +10: " + pt1);
			Console.WriteLine("pt2: " + pt2);
			Console.WriteLine("Классы: присваивание ссылочного типа!");
			CPoint cpt1 = new CPoint(3, 5), cpt2;
			cpt2 = cpt1;
			Console.WriteLine("cpt1: " + cpt1);
			Console.WriteLine("cpt2=cpt1: " + cpt2);
			cpt1.X += 10;
			Console.WriteLine("cpt1.X =cpt1.X +10: " + cpt1);
			Console.WriteLine("cpt2: " + cpt2);
		}

		public static void TestEnum()
		{
			MyColors color1 = MyColors.white;
			TwoColors color2;
			color2 = TwoColors.white;
			if (color1.ToString() != color2.ToString())
				Console.WriteLine("Цвета разные: {0}, {1}", color1, color2);
			else Console.WriteLine("Цвета одинаковые: {0}, {1}", color1, color2);
			Rainbow color3;
			color3 = (Rainbow)3;
			if (color3 != Rainbow.красный) color3 = Rainbow.красный;
			int num = (int)color3;
			Sex who = Sex.man;
			Days first_work_day = (Days)(long)1;
			Console.WriteLine("color1={0}, color2={1}, color3 ={2}", color1, color2, color3);
			Console.WriteLine("who={0}, first_work_day={1}", who, first_work_day);
		}
		public static void TestProfession()
		{
			Person pers1 = new Person("Петров");
			pers1.Prof = Profession.teacher;
			pers1.Analysis();
		}

	}
}
