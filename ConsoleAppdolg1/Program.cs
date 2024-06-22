using System;

namespace ConsoleAppdolg1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Квадратное уравнение"); 
            Console.WriteLine("Введите значения a, b, c: ");
            Console.WriteLine("a = "); 
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("c = ");
            double c = double.Parse(Console.ReadLine());
            double D, x1, x2, x;
            D = b * b - 4 * a * c;
            if (D > 0)
            {
                x1 = (-b + Math.Sqrt(D)) / 2 / a;
                x2 = (-b - Math.Sqrt(D)) / 2 / a;
                Console.WriteLine($"x1 = {x1}");
                Console.WriteLine($"x2 = {x2}");
            }
            else if (D == 0)
            {
                x = -b / 2 / a;
                Console.WriteLine($"x = {x}");
            }
            else Console.WriteLine("Корней нет");
        }
    }
}
