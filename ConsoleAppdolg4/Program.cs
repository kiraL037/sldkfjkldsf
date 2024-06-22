using System;

namespace ConsoleAppdolg4
{
    class Program
    {
        static void Main(string[] args)
        {
			double Pow(double a, double n)
			{
				if (n == 0)
					return 1;
				if (n % 2 == 1)
					return Pow(a, n - 1) * a;
				else
				{
					double b = Pow(a, n / 2);
					return b * b;
				}
			}
			Console.Write("Введите a = ");
			double a = double.Parse(Console.ReadLine());
			Console.Write($"Введите целое n, в которое будет возводиться {a} = ");
			double n = double.Parse(Console.ReadLine());
			Console.WriteLine($"x = {Pow(a, n)}");
		}
    }
}
