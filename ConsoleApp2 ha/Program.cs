using System;

namespace ConsoleApp2_ha
{
    class Testing
    {
        static void Main()
        {
			var p = new Testing();
			p.TestCreateRational();
			Console.WriteLine("\n");
			p.TestPlusRational(); 
			Console.WriteLine("\n");
			p.TestOperRational();
			Console.WriteLine("\n");
			p.TestRationalConst();

		}
		public void TestCreateRational()
		{
			Rational r1 = new Rational(0, 0), r2 = new Rational(1, 1);
			Rational r3 = new Rational(10, 8), r4 = new Rational(2, 6);
			Rational r5 = new Rational(4, -12), r6 = new Rational(-12, -14);
			r1.PrintRational("r1:(0,0)");
			r2.PrintRational("r2:(1,1)");
			r3.PrintRational("r3:(10,8)");
			r4.PrintRational("r4:(2,6)");
			r5.PrintRational("r5: (4,-12)");
			r6.PrintRational("r6: (-12,-14)");
		}
        public void TestOperRational()
        {
            Rational r1 = new Rational(1, 2), r2 = new Rational(1, 3);
            Rational r3, r4, r5, r6;
            r3 = r1 - r2; r4 = r1 * r2; r5 = r1 / r2; r6 = r3 + r4 * r5;
            r1.PrintRational("r1: (1,2)"); r2.PrintRational("r2: (1,3)");
            r3.PrintRational("r3: (r1-r2)"); r4.PrintRational("r4: (r1*r2)");
            r5.PrintRational("r5: (r1/r2)");
            r6.PrintRational("r6: (r3+r4*r5)");
        }
		public void TestPlusRational()
		{
			Rational r1 = new Rational(0, 0), r2 = new Rational(1, 1);
			Rational r3 = new Rational(10, 8), r4 = new Rational(2, 6);
			Rational r5 = new Rational(4, -12), r6 = new Rational
				(-12, -14);
			Rational r7, r8, r9, r10, r11, r12;
			r7 = r1.Plus(r2); r8 = r3.Plus(r4); r9 = r5.Plus(r6);
			r10 = r1 + r2; r11 = r3 + r4; r12 = r5 + r6 + r10 + r11;
			r1.PrintRational("r1:(0,0)"); r2.PrintRational("r2:(1,1)");
			r3.PrintRational("r3:(10,8)"); r4.PrintRational("r4:(2,6)");
			r5.PrintRational("r5: (4,-12)"); r6.PrintRational
				("r6: (-12,-14)");
			r7.PrintRational("r7: (r1+r2)"); r8.PrintRational
				("r8: (r3+r4)");
			r9.PrintRational("r9: (r5+r6)"); r10.PrintRational
				("r10: (r1+r2)");
			r11.PrintRational("r11: (r3+r4)");
			r12.PrintRational("r12: (r5+r6+r10+r11)");
		}
		public void TestRationalConst()
		{
			Rational r1 = new Rational(2, 8), r2 = new Rational(2, 5);
			Rational r3 = new Rational(4, 10), r4 = new Rational(3, 7);
			Rational r5 = Rational.Zero, r6 = Rational.Zero;
			if ((r1 != Rational.Zero) && (r2 == r3)) r5 =
				 (r3 + Rational.One) * r4;
			r6 = Rational.One + Rational.One;
			r1.PrintRational("r1: (2,8)");
			r2.PrintRational("r2: (2,5)");
			r3.PrintRational("r3: (4,10)");
			r4.PrintRational("r4: (3,7)");
			r5.PrintRational("r5: ((r3 +1)*r4)");
			r6.PrintRational("r6: (1+1)");
		}

	}
}
