using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2_ha
{
    public class Rational
    {
        int m, n; 
		public Rational(int a, int b)
		{
			if (b == 0) 
			{
				m = 0; 
				n = 1; 
			}
			else
			{
				if (b < 0) 
				{
					b = -b; 
					a = -a; 
				}
				int d = nod(a, b);
				m = a / d; 
				n = b / d;
			}
			int nod(int m, int n)
			{
				int p = 0;
				m = Math.Abs(m); n = Math.Abs(n);
				if (n > m) 
				{
					p = m; 
					m = n;
					n = p; 
				}
				do
				{
					p = m % n; 
					m = n; 
					n = p;
				} 
				while (n != 0);
				return (m);
			}
		}
		public void PrintRational(string name)
		{
			Console.WriteLine(" {0} = {1}/{2}", name, m, n);
		}
		public Rational Plus(Rational a)
		{
			int u, v;
			u = m * a.n + n * a.m; 
			v = n * a.n;
			return new Rational(u, v);
		}
		public static Rational operator +(Rational r1, Rational r2)
		{
			return r1.Plus(r2);
		}
		public Rational Minus(Rational a)
		{
			int u, v;
			u = m * a.n - n * a.m; v = n * a.n;
			return (new Rational(u, v));
		}
		public static Rational operator -(Rational r1, Rational r2)
		{
			return (r1.Minus(r2));
		}
		public Rational Mult(Rational a)
		{
			int u, v;
			u = m * a.m; v = n * a.n;
			return (new Rational(u, v));
		}
		public static Rational operator *(Rational r1, Rational r2)
		{
			return (r1.Mult(r2));
		}
		public Rational Divide(Rational a)
		{
			int u, v;
			u = m * a.n; v = n * a.m;
			return (new Rational(u, v));
		}
		public static Rational operator /(Rational r1, Rational r2)
		{
			return (r1.Divide(r2));
		}
		private Rational(int a, int b, string t)
		{
			m = a; n = b;
		}
		public static readonly Rational Zero, One;
		static Rational()
		{
			Console.WriteLine("static constructor Rational");
			Zero = new Rational(0, 1, "private");
			One = new Rational(1, 1, "private");
		}
		public static bool operator ==(Rational r1, Rational r2)
		{
			return ((r1.m == r2.m) && (r1.n == r2.n));
		}
		public static bool operator !=(Rational r1, Rational r2)
		{
			return ((r1.m != r2.m) || (r1.n != r2.n));
		}
		public static bool operator <(Rational r1, Rational r2)
		{
			return (r1.m * r2.n < r2.m * r1.n);
		}
		public static bool operator >(Rational r1, Rational r2)
		{
			return (r1.m * r2.n > r2.m * r1.n);
		}
		public static bool operator <(Rational r1, double r2)
		{
			return ((double)r1.m / (double)r1.n < r2);
		}
		public static bool operator >(Rational r1, double r2)
		{
			return ((double)r1.m / (double)r1.n > r2);
		}

	}
}
