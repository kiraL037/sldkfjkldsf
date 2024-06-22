using System;

namespace ConsoleAppdolg6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите число в которое будет возводиться e = ");
            double x = double.Parse(Console.ReadLine());
            double a = Math.Pow(Math.E, x);
            Console.Write($"e ^ {x} = {a}");
            float Fact(float n)
            {
                if (n == 0)
                    return 1;
                else
                    return n * Fact(n - 1);
            }
            double eps = 0.001;
            int n = 0;
            double result = 0;
            double currValue = 1; 
            while (Math.Abs(currValue) > eps)  
            {
                currValue = Math.Pow(x, n) / Fact(n);
                result += currValue;
                n++;
            }
            Console.WriteLine($"\n{result}");
        }
    }
}
