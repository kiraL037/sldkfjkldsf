using System;

namespace ConsoleAppdolg5
{
    class Program
    {
        static void Main(string[] args)
        {
            //double Sqrt(double a, double n)
            //{
            //    double e = 0.001; 
            //    double x0 = a / n; 
            //    double x = ((n - 1) * x0 + a / Math.Pow(x0, n - 1)) / n;
            //    if (Math.Abs(x0 - x) >= e)
            //    {
            //        return x = ((n - 1) * x0 + a / Math.Pow(x0, n - 1)) / n;
            //    }
            //    else return Sqrt(a, n);
            //    //a = ((n - 1) * (a / n) + a / Math.Pow(a / n, n - 1)) / n;
            //    //if (Math.Abs(a) < e)
            //    //    return a;
            //    //return Sqrt(a, n);
            //}
            Console.Write("Введите a = ");
            double a = double.Parse(Console.ReadLine());
            if (a < 0)
            {
                Console.Write("Ошибка, число отрицательное ");
                return;
            }
            Console.Write($"Введите целое n, которое будет являться степенью корня {a} = ");
            double n = double.Parse(Console.ReadLine());
            double e = 0.00001;
            double x0 = a / n;
            double x = ((n - 1) * x0 + a / Math.Pow(x0, n - 1)) / n;
            while (Math.Abs(x0 - x) >= e)
            {
                x0 = x;
                x = ((n - 1) * x0 + a / Math.Pow(x0, n - 1)) / n;
            }
            Console.WriteLine(x);
            //Console.WriteLine($"x = {Sqrt(a, n)}");
        }
    }
}
