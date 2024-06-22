using System;

namespace ConsoleAppdolg3
{
    class Program
    {
        static void Main(string[] args)
        {
            double Pow(double x, double n)
            {
                if (n == 0)
                    return 1;
                if (n > 0)
                    return Pow(x, n - 1) * x;
                return Pow(x, n);
            }
            Console.Write("Введите x = ");
            double x = double.Parse(Console.ReadLine());
            Console.Write($"Введите целое n, в которое будет возводиться {x} = ");
            double n = double.Parse(Console.ReadLine());
            Console.WriteLine($"x = {Pow(x, n)}");
        }
    }
}
