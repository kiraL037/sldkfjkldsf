using System;
using System.Drawing;

namespace ConsoleApp2_ha_stru
{
    class Program
    {
        static void Main()
        {
			var p = new Program();
			p.TestPointAndSize();
            p.TestTwoSemantics();
        }
		public void TestPointAndSize()
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
        public void TestTwoSemantics()
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

    }
}
