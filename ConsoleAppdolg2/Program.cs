using System;

namespace ConsoleAppdolg2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Определение вида треугольника по сторонам ");
            Console.WriteLine("Введите в порядке возрастания значения a, b, c:");
            Console.Write("a = ");
            double a = double.Parse(Console.ReadLine());
            Console.Write("b = ");
            double b = double.Parse(Console.ReadLine());
            Console.Write("c = ");
            double c = double.Parse(Console.ReadLine());
            if (a > b || b > c)
                Console.WriteLine("Числа не соответствуют условию");
            else if (a > 0 && b > 0 && c > 0)
                if (a + b > c && a + c > b && b + c > a)
                {
                    double eps = 0.1;
                    double A = c * c - (a * a + b * b);
                    if (Math.Abs(A) < eps)
                        Console.WriteLine("Треугольник прямоугольный"); 
                    else if (a == b && b == c)
                        Console.WriteLine("Треугольник равносторонний");
                    else if (a == b || b == c || a == c)
                        Console.WriteLine("Треугольник равнобедренный");
                    else Console.WriteLine("Треугольник разносторонний, но не прямоугольный");
                }
            else
                Console.WriteLine("Треугольник не существует");
        }
    }
}
