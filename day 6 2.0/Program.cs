using System;

namespace day_6_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Calc calc = new Calc();
            int a = 1, b = 2, c = 3;
            int ans1 = calc.Add(a, b);
            int ans2 = calc.Add(a, b, c);
            Console.WriteLine("{0}+{1}+{2}", a, b, ans1);
            Console.WriteLine("{0}+{1}+{2}={3}", a, b, c, ans2);
        }
    }
}
